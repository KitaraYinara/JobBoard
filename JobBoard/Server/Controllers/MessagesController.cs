using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.Server.Data;
using JobBoard.Shared.Domain;
using JobBoard.Server.IRepository;

namespace JobBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public MessagesController(ApplicationDbContext context)
        public MessagesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Messages
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        public async Task<IActionResult> GetMessages()
        {
            //if (_context.Messages == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Messages.ToListAsync();
            var Messages = await _unitOfWork.Messages.GetAll(includes: q => q.Include(x => x.Employer).Include(x => x.Applicant));
            if (Messages == null)
            {
                return NotFound();
            }
            return Ok(Messages);
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Message>> GetMessage(int id)
        public async Task<IActionResult> GetMessage(int id)
        {
            /*if (_context.Messages == null)
            {
                return NotFound();
            }
              var Message = await _context.Messages.FindAsync(id);

              if (Message == null)
              {
                  return NotFound();
              }

              return Message;
            */
            var Message = await _unitOfWork.Messages.Get(q => q.Id == id);

            if (Message == null)
            {
                return NotFound();
            }

            return Ok(Message);
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message Message)
        {
            if (id != Message.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Message).State = EntityState.Modified;
            _unitOfWork.Messages.Update(Message);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message Message)
        {
            //if (_context.Messages == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
            //}
            //  _context.Messages.Add(Message);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Messages.Insert(Message);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMessage", new { id = Message.Id }, Message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            //if (_context.Messages == null)
            //{
            //    return NotFound();
            //}
            var Message = _unitOfWork.Messages.Get(q => q.Id == id);
            if (Message == null)
            {
                return NotFound();
            }

            //_context.Messages.Remove(Message);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Messages.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> MessageExists(int id)
        {
            //return (_context.Messages?.Any(e => e.Id == id)).GetValueOrDefault();
            var Message = await _unitOfWork.Messages.Get(q => q.Id == id);

            return Message != null;
        }
    }
}

