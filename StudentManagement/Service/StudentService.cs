using Azure;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace StudentManagement.Service
{
    public class StudentService : IStudentService
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

            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Cannot Add Student";
                return response;
            }
            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Student Added";
            }
            return response;
        }
        public object GetStudent(Guid Id)
        {
            var student = dbContext.Students.Find(Id);
            int len = student == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = student;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            var obj = from t in dbContext.Teachers where t.Subject == student.Subject select new { t.TeacherName, t.Subject };
            if (obj != null)
            {
                if (len == 1)
                {
                    response.Data = obj;
                    response.StatusCode = 200;
                    response.Message = "Student Details";
                }
            }
            return response;
        }
        public object DeleteStudent(Guid Id)
        {
            var obj = dbContext.Students.Find(Id);
            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            if (obj != null)
            {
                dbContext.Remove(obj);
                dbContext.SaveChanges();
                if (len == 1)
                {
                    response.Data = obj;
                    response.StatusCode = 200;
                    response.Message = "Student deleted";
                }
            }
            return response;
        }
        public object UpdateStudent(Guid Id, UpdateStudent updateStudent)
        {
          
            var obj = dbContext.Students.Find(Id);
            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            if (updateStudent.StudentName != "string") { obj.StudentName = updateStudent.StudentName; }
            if (updateStudent.Email != "string") { obj.Email = updateStudent.Email; }
            if (updateStudent.Password != "string") { obj.Password = updateStudent.Password; }
            if (updateStudent.Subject != "string") { obj.Subject = updateStudent.Subject; }

            dbContext.SaveChanges();

            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Student details updated";
            }
            return response;
        }
    }
}
