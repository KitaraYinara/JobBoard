using JobBoard.Shared.Domain;
using System.Drawing;

namespace JobBoard.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Admin> Admins { get; }
        IGenericRepository<Applicant> Applicants { get; }
        IGenericRepository<Company> Companies { get; }
        IGenericRepository<Employer> Employers { get; }
        IGenericRepository<Industry> Industries { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<JobApplication> JobApplications { get; }
        IGenericRepository<Message> Messages { get; }
        IGenericRepository<Search> Searches { get; }
    }
}
