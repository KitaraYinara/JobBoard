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
    public class AdminsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public AdminsController(ApplicationDbContext context)
        public AdminsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Admins
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        public async Task<IActionResult> GetAdmins()
        {

            //if (_context.Admins == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Admins.ToListAsync();
            var Admins = await _unitOfWork.Admins.GetAll();
            if (Admins == null)
            {
                return NotFound();
            }
            return Ok(Admins);
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Admin>> GetAdmin(int id)
        public async Task<IActionResult> GetAdmin(int id)
        {
            /*if (_context.Admins == null)
            {
                return NotFound();
            }
              var Admin = await _context.Admins.FindAsync(id);

              if (Admin == null)
              {
                  return NotFound();
              }

              return Admin;
            */
            var Admin = await _unitOfWork.Admins.Get(q => q.Id == id);

            if (Admin == null)
            {
                return NotFound();
            }

            return Ok(Admin);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin Admin)
        {
            if (id != Admin.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Admin).State = EntityState.Modified;
            _unitOfWork.Admins.Update(Admin);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AdminExists(id))
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

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin Admin)
        {
            //if (_context.Admins == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Admins'  is null.");
            //}
            //  _context.Admins.Add(Admin);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Admins.Insert(Admin);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAdmin", new { id = Admin.Id }, Admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            //if (_context.Admins == null)
            //{
            //    return NotFound();
            //}
            var Admin = _unitOfWork.Admins.Get(q => q.Id == id);
            if (Admin == null)
            {
                return NotFound();
            }

            //_context.Admins.Remove(Admin);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Admins.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> AdminExists(int id)
        {
            //return (_context.Admins?.Any(e => e.Id == id)).GetValueOrDefault();
            var Admin = await _unitOfWork.Admins.Get(q => q.Id == id);

            return Admin != null;
        }
    }
}

