using JobBoard.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Server.Configurations.Entities
{
    public class CompanySeedConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
             new Company
             {
                 Id = 1,
                 C_Name = "EduFlex Connect",
                 C_Address = "345 Orchard Road Singapore 567890",
                 C_About = "EduFlex Connect is a pioneering education staffing agency committed to revolutionizing the teaching landscape. Specializing in part-time teaching placements, we bridge the gap between qualified educators and schools seeking dynamic talent. Based in Singapore, our company strategically matches passionate teachers with diverse educational institutions, creating enriching learning environments. Offering flexibility and personalized placements, EduFlex Connect empowers educators to pursue their passion while schools benefit from experienced professionals. Join us in shaping the future of education, where teaching meets flexibility seamlessly. Your journey with EduFlex Connect starts here, connecting educators and schools for a brighter tomorrow.",
                 AdminId = 1,
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Company
             {
                 Id = 2,
                 C_Name = "CreativeHarbor Productions",
                 C_Address = "123 Marina Bay Drive, Singapore 123456",
                 C_About = "CreativeHarbor Productions is a dynamic production company specializing in crafting compelling content for film, television, and digital media. Our experienced team collaborates with creatives to bring imaginative visions to life, ensuring seamless execution from concept to completion. Committed to diversity and inclusion, we foster a collaborative environment where unique voices thrive. From gripping feature films to cutting-edge digital projects, CreativeHarbor pushes storytelling boundaries. With a focus on innovation, quality, and a deep respect for the art, we transform dreams into reality, making a lasting impact in the entertainment industry. Welcome to a world where creativity knows no bounds.",
                 AdminId = 2,
                 CreatedBy = "System",
                 UpdatedBy = "System"
             }
            );
        }
    }
}
