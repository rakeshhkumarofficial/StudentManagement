using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string? StudentName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Subject { get; set; }
    }
}
