using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string? TeacherName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Subject { get; set; }
    }
}
