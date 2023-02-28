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
            return obj;
        }

        public object GetTeacher(Guid Id)
        {
            var teacher = dbContext.Teachers.Find(Id);
            var obj = from s in dbContext.Students where s.Subject == teacher.Subject select new {s.Subject, s.StudentName};
            return obj;
        }
    }
}
