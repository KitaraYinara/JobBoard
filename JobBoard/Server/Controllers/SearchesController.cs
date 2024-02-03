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
    public class SearchesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public AdminsController(ApplicationDbContext context)
        public SearchesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Admins
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        public async Task<IActionResult> GetSearches()
        {

            //if (_context.Admins == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Admins.ToListAsync();
            var Searches = await _unitOfWork.Searches.GetAll(includes: q => q.Include(x => x.Applicant).Include(x => x.Job));
            if (Searches == null)
            {
                return NotFound();
            }
            return Ok(Searches);
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Admin>> GetAdmin(int id)
        public async Task<IActionResult> GetSearch(int id)
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
            var Search = await _unitOfWork.Searches.Get(q => q.Id == id);

            if (Search == null)
            {
                return NotFound();
            }

            return Ok(Search);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearch(int id, Search Search)
        {
            if (id != Search.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Admin).State = EntityState.Modified;
            _unitOfWork.Searches.Update(Search);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SearchExists(id))
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
        public async Task<ActionResult<Search>> PostSearch(Search Search)
        {
            //if (_context.Admins == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Admins'  is null.");
            //}
            //  _context.Admins.Add(Admin);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Searches.Insert(Search);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSearch", new { id = Search.Id }, Search);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearch(int id)
        {
            //if (_context.Admins == null)
            //{
            //    return NotFound();
            //}
            var Search = _unitOfWork.Searches.Get(q => q.Id == id);
            if (Search == null)
            {
                return NotFound();
            }

            //_context.Admins.Remove(Admin);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Searches.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> SearchExists(int id)
        {
            //return (_context.Admins?.Any(e => e.Id == id)).GetValueOrDefault();
            var Search = await _unitOfWork.Searches.Get(q => q.Id == id);

            return Search != null;
        }
    }
}