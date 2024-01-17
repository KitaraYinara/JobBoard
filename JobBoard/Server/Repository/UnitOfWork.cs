using JobBoard.Server.Data;
using JobBoard.Server.IRepository;
using JobBoard.Server.Models;
using JobBoard.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace JobBoard.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Admin> _admins;
        private IGenericRepository<Applicant> _applicants;
        private IGenericRepository<Company> _companies;
        private IGenericRepository<Employer> _employers;
        private IGenericRepository<Industry> _industries;
        private IGenericRepository<Job> _jobs;
        private IGenericRepository<JobApplication> _jobapplications;
        private IGenericRepository<Message> _messages;
        private IGenericRepository<Search> _searches;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IGenericRepository<Admin> Admins
            => _admins ??= new GenericRepository<Admin>(_context);
        public IGenericRepository<Applicant> Applicants
            => _applicants ??= new GenericRepository<Applicant>(_context);
        public IGenericRepository<Company> Companies
            => _companies ??= new GenericRepository<Company>(_context);
        public IGenericRepository<Employer> Employers
            => _employers ??= new GenericRepository<Employer>(_context);
        public IGenericRepository<Industry> Industries
            => _industries ??= new GenericRepository<Industry>(_context);
        public IGenericRepository<Job> Jobs
            => _jobs ??= new GenericRepository<Job>(_context);
        public IGenericRepository<JobApplication> JobApplications
            => _jobapplications ??= new GenericRepository<JobApplication>(_context);
        public IGenericRepository<Message> Messages
            => _messages ??= new GenericRepository<Message>(_context);
        public IGenericRepository<Search> Searches
            => _searches ??= new GenericRepository<Search>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
