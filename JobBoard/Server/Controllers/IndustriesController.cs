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
    public class IndustriesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public IndustriesController(ApplicationDbContext context)
        public IndustriesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Industries
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Industries>>> GetIndustries()
        public async Task<IActionResult> GetIndustries()
        {
            //if (_context.Industries == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Industries.ToListAsync();
            var Industries = await _unitOfWork.Industries.GetAll();
            if (Industries == null)
            {
                return NotFound();
            }
            return Ok(Industries);
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Industries>> GetIndustries(int id)
        public async Task<IActionResult> GetIndustries(int id)
        {
            /*if (_context.Industries == null)
            {
                return NotFound();
            }
              var Industries = await _context.Industries.FindAsync(id);

              if (Industries == null)
              {
                  return NotFound();
              }

              return Industries;
            */
            var Industries = await _unitOfWork.Industries.Get(q => q.Id == id);

            if (Industries == null)
            {
                return NotFound();
            }

            return Ok(Industries);
        }

        // PUT: api/Industries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustries(int id, Industry Industries)
        {
            if (id != Industries.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Industries).State = EntityState.Modified;
            _unitOfWork.Industries.Update(Industries);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IndustriesExists(id))
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

        // POST: api/Industries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Industry>> PostIndustries(Industry Industries)
        {
            //if (_context.Industries == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Industries'  is null.");
            //}
            //  _context.Industries.Add(Industries);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Industries.Insert(Industries);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetIndustries", new { id = Industries.Id }, Industries);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIndustries(int id)
        {
            //if (_context.Industries == null)
            //{
            //    return NotFound();
            //}
            var Industries = _unitOfWork.Industries.Get(q => q.Id == id);
            if (Industries == null)
            {
                return NotFound();
            }

            //_context.Industries.Remove(Industries);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Industries.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> IndustriesExists(int id)
        {
            //return (_context.Industries?.Any(e => e.Id == id)).GetValueOrDefault();
            var Industries = await _unitOfWork.Industries.Get(q => q.Id == id);

            return Industries != null;
        }
    }
}

