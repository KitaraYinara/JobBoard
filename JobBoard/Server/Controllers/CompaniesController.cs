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
    public class CompaniesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public CompaniesController(ApplicationDbContext context)
        public CompaniesController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Companies
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Companies>>> GetCompanies()
        public async Task<IActionResult> GetCompanies()
        {
            //if (_context.Companies == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Companies.ToListAsync();
            var Companies = await _unitOfWork.Companies.GetAll(includes: q => q.Include(x => x.Admin));
            if (Companies == null)
            {
                return NotFound();
            }
            return Ok(Companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Companies>> GetCompanies(int id)
        public async Task<IActionResult> GetCompanies(int id)
        {
            /*if (_context.Companies == null)
            {
                return NotFound();
            }
              var Companies = await _context.Companies.FindAsync(id);

              if (Companies == null)
              {
                  return NotFound();
              }

              return Companies;
            */
            var Companies = await _unitOfWork.Companies.Get(q => q.Id == id);

            if (Companies == null)
            {
                return NotFound();
            }

            return Ok(Companies);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(int id, Company Companies)
        {
            if (id != Companies.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Companies).State = EntityState.Modified;
            _unitOfWork.Companies.Update(Companies);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CompaniesExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompanies(Company Companies)
        {
            //if (_context.Companies == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Companies'  is null.");
            //}
            //  _context.Companies.Add(Companies);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Companies.Insert(Companies);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCompanies", new { id = Companies.Id }, Companies);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanies(int id)
        {
            //if (_context.Companies == null)
            //{
            //    return NotFound();
            //}
            var Companies = _unitOfWork.Companies.Get(q => q.Id == id);
            if (Companies == null)
            {
                return NotFound();
            }

            //_context.Companies.Remove(Companies);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Companies.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CompaniesExists(int id)
        {
            //return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
            var Companies = await _unitOfWork.Companies.Get(q => q.Id == id);

            return Companies != null;
        }
    }
}
