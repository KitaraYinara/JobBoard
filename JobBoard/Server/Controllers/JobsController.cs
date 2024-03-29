﻿using System;
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
    public class JobsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public JobsController(ApplicationDbContext context)
        public JobsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Jobs
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        public async Task<IActionResult> GetJobs()
        {
            //if (_context.Jobs == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Jobs.ToListAsync();
            var jobs = await _unitOfWork.Jobs.GetAll(includes: q => q.Include(x => x.Employer).Include(x => x.Industry));
            if (jobs == null)
            {
                return NotFound();
            }
            return Ok(jobs);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Job>> GetJob(int id)
        public async Task<IActionResult> GetJob(int id)
        {
            /*if (_context.Jobs == null)
            {
                return NotFound();
            }
              var job = await _context.Jobs.FindAsync(id);

              if (job == null)
              {
                  return NotFound();
              }

              return job;
            */
            var job = await _unitOfWork.Jobs.Get(q => q.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            //_context.Entry(job).State = EntityState.Modified;
            _unitOfWork.Jobs.Update(job);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await JobExists(id))
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

        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            //if (_context.Jobs == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Jobs'  is null.");
            //}
            //  _context.Jobs.Add(job);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Jobs.Insert(job);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            //if (_context.Jobs == null)
            //{
            //    return NotFound();
            //}
            var job = _unitOfWork.Jobs.Get(q => q.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            //_context.Jobs.Remove(job);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Jobs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> JobExists(int id)
        {
            //return (_context.Jobs?.Any(e => e.Id == id)).GetValueOrDefault();
            var job = await _unitOfWork.Jobs.Get(q => q.Id == id);

            return job != null;
        }
    }
}
