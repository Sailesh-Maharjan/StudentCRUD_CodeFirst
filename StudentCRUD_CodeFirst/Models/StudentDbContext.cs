using Microsoft.EntityFrameworkCore;

namespace StudentCRUD_CodeFirst.Models
{
    public class StudentDbContext:DbContext
    { 
        public StudentDbContext(DbContextOptions<StudentDbContext>Option):base(Option)
        {
                
        }
        public DbSet<Student> Students { get; set; }
    }
}
