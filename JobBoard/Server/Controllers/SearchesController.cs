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
        //public SearchsController(ApplicationDbContext context)
        public SearchesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Searchs
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Search>>> GetSearchs()
        public async Task<IActionResult> GetSearchs()
        {
            //if (_context.Searchs == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Searchs.ToListAsync();
            var Searches = await _unitOfWork.Searches.GetAll(includes: q => q.Include(x => x.Job).Include(x => x.Applicant));
            if (Searches == null)
            {
                return NotFound();
            }
            return Ok(Searches);
        }

        // GET: api/Searchs/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Search>> GetSearch(int id)
        public async Task<IActionResult> GetSearch(int id)
        {
            /*if (_context.Searchs == null)
            {
                return NotFound();
            }
              var Search = await _context.Searchs.FindAsync(id);

              if (Search == null)
              {
                  return NotFound();
              }

              return Search;
            */
            var Searches = await _unitOfWork.Searches.Get(q => q.Id == id);

            if (Searches == null)
            {
                return NotFound();
            }

            return Ok(Searches);
        }

        // PUT: api/Searchs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearch(int id, Search Searches)
        {
            if (id != Searches.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Search).State = EntityState.Modified;
            _unitOfWork.Searches.Update(Searches);

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

        // POST: api/Searchs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Search>> PostSearch(Search Searches)
        {
            //if (_context.Searchs == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Searchs'  is null.");
            //}
            //  _context.Searchs.Add(Search);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Searches.Insert(Searches);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSearch", new { id = Searches.Id }, Searches);
        }

        // DELETE: api/Searchs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearch(int id)
        {
            //if (_context.Searchs == null)
            //{
            //    return NotFound();
            //}
            var Searches = _unitOfWork.Searches.Get(q => q.Id == id);
            if (Searches == null)
            {
                return NotFound();
            }

            //_context.Searchs.Remove(Search);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Searches.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> SearchExists(int id)
        {
            //return (_context.Searchs?.Any(e => e.Id == id)).GetValueOrDefault();
            var Searches = await _unitOfWork.Searches.Get(q => q.Id == id);

            return Searches != null;
        }
    }
}

