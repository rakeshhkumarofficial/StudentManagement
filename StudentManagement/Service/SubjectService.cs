using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly StudentManagementAPIDbContext dbContext;
        public SubjectService(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public object AddSubject(Subject subject)
        {
            var obj = new Subject()
            {
                Id = Guid.NewGuid(),
                SubjectName = subject.SubjectName,
            };
            dbContext.Subjects.Add(obj);
            dbContext.SaveChanges();
            return obj;
        }
    }
}
