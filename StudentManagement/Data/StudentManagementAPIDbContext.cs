using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class StudentManagementAPIDbContext : DbContext
    {
        public StudentManagementAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
