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
    public class JobApplicationsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public JobApplicationsController(ApplicationDbContext context)
        public JobApplicationsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobApplications
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplications()
        public async Task<IActionResult> GetJobApplications()
        {
            //if (_context.JobApplications == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.JobApplications.ToListAsync();
            var JobApplications = await _unitOfWork.JobApplications.GetAll(includes: q => q.Include(x => x.Job).Include(x => x.Applicant));
            if (JobApplications == null)
            {
                return NotFound();
            }
            return Ok(JobApplications);
        }

        // GET: api/JobApplications/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
        public async Task<IActionResult> GetJobApplication(int id)
        {
            /*if (_context.JobApplications == null)
            {
                return NotFound();
            }
              var JobApplication = await _context.JobApplications.FindAsync(id);

              if (JobApplication == null)
              {
                  return NotFound();
              }

              return JobApplication;
            */
            var JobApplication = await _unitOfWork.JobApplications.Get(q => q.Id == id);

            if (JobApplication == null)
            {
                return NotFound();
            }

            return Ok(JobApplication);
        }

        // PUT: api/JobApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobApplication(int id, JobApplication JobApplication)
        {
            if (id != JobApplication.Id)
            {
                return BadRequest();
            }

            //_context.Entry(JobApplication).State = EntityState.Modified;
            _unitOfWork.JobApplications.Update(JobApplication);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await JobApplicationExists(id))
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

        // POST: api/JobApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication JobApplication)
        {
            //if (_context.JobApplications == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.JobApplications'  is null.");
            //}
            //  _context.JobApplications.Add(JobApplication);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.JobApplications.Insert(JobApplication);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetJobApplication", new { id = JobApplication.Id }, JobApplication);
        }

        // DELETE: api/JobApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            //if (_context.JobApplications == null)
            //{
            //    return NotFound();
            //}
            var JobApplication = _unitOfWork.JobApplications.Get(q => q.Id == id);
            if (JobApplication == null)
            {
                return NotFound();
            }

            //_context.JobApplications.Remove(JobApplication);
            //await _context.SaveChangesAsync();
            await _unitOfWork.JobApplications.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> JobApplicationExists(int id)
        {
            //return (_context.JobApplications?.Any(e => e.Id == id)).GetValueOrDefault();
            var JobApplication = await _unitOfWork.JobApplications.Get(q => q.Id == id);

            return JobApplication != null;
        }
    }
}

