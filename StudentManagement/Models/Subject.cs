using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string? SubjectName { get; set; }
    }
}
