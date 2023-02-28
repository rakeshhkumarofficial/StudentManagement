using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly StudentManagementAPIDbContext dbContext;

        public TeacherService(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public object AddTeacher(Teacher teacher)
        {
            var obj = new Teacher()
            {
                Id = Guid.NewGuid(),
                TeacherName = teacher.TeacherName,
                Email= teacher.Email,
                Password= teacher.Password,
                Subject= teacher.Subject,
            };
            dbContext.Teachers.Add(obj);
            dbContext.SaveChanges();

            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Cannot Add Teacher";
                return response;
            }
            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Teacher Added";
            }
            return response;
        }
        public object GetTeacher(Guid Id)
        {
            var teacher = dbContext.Teachers.Find(Id);
            int len = teacher == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = teacher;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            var obj = from s in dbContext.Students where s.Subject == teacher.Subject select new {s.Subject, s.StudentName};
            if (obj != null)
            {
                if (len == 1)
                {
                    response.Data = obj;
                    response.StatusCode = 200;
                    response.Message = "Teacher Details";
                }
            }
            return response;
        }
        public object DeleteTeacher(Guid Id)
        {
            var obj = dbContext.Teachers.Find(Id);
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
                    response.Message = "Teacher deleted";
                }
            }
            return response;
            
        }
        public object UpdateTeacher(Guid Id, UpdateTeacher updateTeacher)
        {

            var obj = dbContext.Teachers.Find(Id);
            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            if (updateTeacher.TeacherName != "string") { obj.TeacherName = updateTeacher.TeacherName; }
            if (updateTeacher.Email != "string") { obj.Email = updateTeacher.Email; }
            if (updateTeacher.Password != "string") { obj.Password = updateTeacher.Password; }
            if (updateTeacher.Subject != "string") { obj.Subject = updateTeacher.Subject; }

            dbContext.SaveChanges();

            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Teacher details updated";
            }
            return response;
        }
    }
}
