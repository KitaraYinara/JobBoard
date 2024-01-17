using JobBoard.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace JobBoard.Server.Configurations.Entities
{
    public class AdminSeedConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
             new Admin
             {
                 Id = 1,
                 Ad_Name = "John Lee",
                 Ad_Email = "Test@Blazor.sg",
                 Ad_Password = "P@ssword12",
                 Ad_Age = 25,
                 Ad_Mobile = "81234567",
                 Ad_DateOfBirth = new DateTime(1998, 09, 27),
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Admin
             {
                Id = 2,
                Ad_Name = "Mary Jane",
                Ad_Email = "Test@yahoo.sg",
                Ad_Password = "P@ssword1",
                Ad_Age = 23,
                Ad_Mobile = "94123567",
                Ad_DateOfBirth = new DateTime(2000, 08, 13),
                CreatedBy = "System",
                UpdatedBy = "System"
             }
            );
        }
    }
}