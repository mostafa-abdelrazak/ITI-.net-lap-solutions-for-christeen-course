using Microsoft.EntityFrameworkCore;

namespace day2.Models
{
    public class DbSet : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=. ;Database = ITIChristenMVC;Trusted_Connection = true ; TrustServerCertificate = true ");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
