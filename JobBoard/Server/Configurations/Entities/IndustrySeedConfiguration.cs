using System.Drawing;
using JobBoard.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace JobBoard.Server.Configurations.Entities
{
    public class IndustrySeedConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.HasData(
             new Industry {
                 Id = 1,
                 I_Type = "Education",
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Industry {
                 Id = 2,
                 I_Type = "Entertainment",
                 CreatedBy = "System",
                 UpdatedBy = "System"
             }, 
             new Industry {
                 Id = 3,
                 I_Type = "Food",
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Industry
             {
                Id = 4,
                I_Type = "Fashion",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 5,
                I_Type = "Healthcare",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 6,
                I_Type = "Agriculture",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 7,
                I_Type = "Transport",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 8,
                I_Type = "Manufacturing",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 9,
                I_Type = "Media",
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Industry
             {
                Id = 10,
                I_Type = "E Commerce",
                CreatedBy = "System",
                UpdatedBy = "System"
                          }
            );
        }
    }
}
