using StudentManagement.Data;
using StudentManagement.Models;
using System.Security.Cryptography.X509Certificates;

namespace StudentManagement.Service
{
    public class StudentService : IStudentservice
    {
        private readonly StudentManagementAPIDbContext dbContext;
        public StudentService(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public object AddStudent(Student student)
        {
            var obj = new Student()
            {
                Id = Guid.NewGuid(),
                StudentName = student.StudentName,
                Email = student.Email,
                Password = student.Password,
                Subject = student.Subject,
            };
            dbContext.Students.Add(obj);
            dbContext.SaveChanges();
            return obj;
        }
        public object GetStudent(Guid Id)
        {
            var student = dbContext.Students.Find(Id);
            if (student == null)
            {
                return "Not Found";
            }
            var obj = from t in dbContext.Teachers where t.Subject == student.Subject select new { t.TeacherName, t.Subject };
            if (obj != null)
            {
                return obj;
            }
            return "Not Found";
        }
        public object DeleteStudent(Guid Id)
        {
            var obj = dbContext.Students.Find(Id);
            if (obj != null)
            {
                dbContext.Remove(obj);
                dbContext.SaveChanges();
                return obj;
            }
            return "Not Found";
        }
    }
}
