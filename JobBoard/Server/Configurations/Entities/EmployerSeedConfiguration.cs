using JobBoard.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Server.Configurations.Entities
{
    public class EmployerSeedConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasData(
             new Employer
             {
                 Id = 1,
                 E_Name = "Veronica Kim",
                 E_Email = "Veronica1@gmail.com",
                 E_Password = "Ys1posN@ss",
                 E_Age = 23,
                 E_Mobile = "92674012",
                 E_DateOfBirth = new DateTime(2000, 09, 08),
                 CompanyId = 1,
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Employer
             {
                 Id = 2,
                 E_Name = "Sean Lee",
                 E_Email = "Sean1@gmail.com",
                 E_Password = "st@gva1sl",
                 E_Age = 25,
                 E_Mobile = "87640291",
                 E_DateOfBirth = new DateTime(1998, 05, 12),
                 CompanyId = 2,
                 CreatedBy = "System",
                 UpdatedBy = "System"
             }
            );
        }
    }
}
