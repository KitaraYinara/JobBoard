using JobBoard.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Server.Configurations.Entities
{
    public class JobSeedConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(
             new Job
             {
                 Id = 1,
                 J_Name = "Part Time Teacher",
                 J_Location = "Singapore",
                 J_Description = "We are seeking a dedicated and enthusiastic Part-Time Teacher to join our school faculty. The ideal candidate will be passionate about education, possess excellent communication skills, and have the ability to create a positive and engaging learning environment. As a Part-Time Teacher, you will be responsible for delivering high-quality instruction, fostering student growth, and contributing to the overall success of the school.",
                 J_Salary = 11,
                 J_Type = "Part-Time",
                 J_Skills = "Communication, Leadership, Critical Thinking, Time Management",
                 J_Urgency = false,
                 EmployerId = 1,
                 IndustryId = 1,
                 DateCreated = new DateTime(2017, 08, 25),
                 DateUpdated = new DateTime(2017, 08, 25),
                 CreatedBy = "System",
                 UpdatedBy = "System"
             },
             new Job
             {
                Id = 2,
                J_Name = "Producer",
                J_Location = "Singapore",
                J_Description = "Looking for a Producer who will work on the morning drive time show. Responsibilities: Develop and produce innovative and creative audio and video programming for radio, podcast and digital platforms which will seize the audience’s attention while meeting the highest editorial standards",
                J_Salary = 30,
                J_Type = "Full-Time",
                J_Skills = "Degree in Journalism, Mass Communications, Political Science or the Arts and Social Sciences , Creative, Resourceful, Communication, ",
                J_Urgency = false,
                EmployerId = 2,
                IndustryId = 2,
                DateCreated = new DateTime(2015, 06, 20),
                DateUpdated = new DateTime(2015, 06, 20),
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Job
             {
                Id = 3,
                J_Name = "Amazon Senior Website Engineer",
                J_Location = "Singapore",
                J_Description = "Handle the Amazon website as a maintenance staff",
                J_Type = "Full-Time",
                J_Skills = "HTML, CSS, JavaScript, Python , C#, C, Database SQL",
                J_Urgency = false,
                EmployerId = 1,
                IndustryId = 10,
                DateCreated = new DateTime(2010, 01, 20),
                DateUpdated = new DateTime(2010, 01, 20),
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Job
             {
                Id = 4,
                J_Name = "Google Engineer",
                J_Location = "Singapore",
                J_Description = "An engineer position where you would be handling the maintenance work around the offices",
                J_Type = "Full-Time",
                J_Skills = "Engineering Degree, Mechanic Experience",
                J_Urgency = true,
                EmployerId = 2,
                IndustryId = 10,
                DateCreated = new DateTime(2014, 09, 10),
                DateUpdated = new DateTime(2014, 09, 10),
                CreatedBy = "System",
                UpdatedBy = "System"
             },
             new Job
             {
                Id = 5,
                J_Name = "Apple Manager",
                J_Location = "Singapore",
                J_Description = "An managerial position where you would be handling small teams in projects",
                J_Type = "Full-Time",
                J_Skills = "Business Degree, Team Experience",
                J_Urgency = true,
                EmployerId = 1,
                IndustryId = 10,
                DateCreated = new DateTime(2009, 01, 25),
                DateUpdated = new DateTime(2009, 01, 25),
                CreatedBy = "System",
                UpdatedBy = "System"
             }
            );
        }
    }
}
