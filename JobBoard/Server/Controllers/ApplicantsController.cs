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
    public class ApplicantsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ApplicantsController(ApplicationDbContext context)
        public ApplicantsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Applicants
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        public async Task<IActionResult> GetApplicants()
        {
            //if (_context.Applicants == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Applicants.ToListAsync();
            var Applicants = await _unitOfWork.Applicants.GetAll();
            if (Applicants == null)
            {
                return NotFound();
            }
            return Ok(Applicants);
        }

        // GET: api/Applicants/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Applicant>> GetApplicant(int id)
        public async Task<IActionResult> GetApplicant(int id)
        {
            /*if (_context.Applicants == null)
            {
                return NotFound();
            }
              var Applicant = await _context.Applicants.FindAsync(id);

              if (Applicant == null)
              {
                  return NotFound();
              }

              return Applicant;
            */
            var Applicant = await _unitOfWork.Applicants.Get(q => q.Id == id);

            if (Applicant == null)
            {
                return NotFound();
            }

            return Ok(Applicant);
        }

        // PUT: api/Applicants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicant(int id, Applicant Applicant)
        {
            if (id != Applicant.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Applicant).State = EntityState.Modified;
            _unitOfWork.Applicants.Update(Applicant);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ApplicantExists(id))
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

        // POST: api/Applicants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicant(Applicant Applicant)
        {
            //if (_context.Applicants == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Applicants'  is null.");
            //}
            //  _context.Applicants.Add(Applicant);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Applicants.Insert(Applicant);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetApplicant", new { id = Applicant.Id }, Applicant);
        }

        // DELETE: api/Applicants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            //if (_context.Applicants == null)
            //{
            //    return NotFound();
            //}
            var Applicant = _unitOfWork.Applicants.Get(q => q.Id == id);
            if (Applicant == null)
            {
                return NotFound();
            }

            //_context.Applicants.Remove(Applicant);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Applicants.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ApplicantExists(int id)
        {
            //return (_context.Applicants?.Any(e => e.Id == id)).GetValueOrDefault();
            var Applicant = await _unitOfWork.Applicants.Get(q => q.Id == id);

            return Applicant != null;
        }
    }
}
