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
            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Cannot Add Subject";
                return response;
            }
            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Subject Added";
            }
            return response;
        }
        public object GetSubject()
        {
            var obj = dbContext.Subjects;
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
                if (len == 1)
                {
                    response.Data = obj;
                    response.StatusCode = 200;
                    response.Message = "Subjects Details";
                }
            }
            return response;
        }
        public object DeleteSubject(Guid Id)
        {
            var obj = dbContext.Subjects.Find(Id);
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
                    response.Message = "Subject deleted";
                }
            }
            return response;
        }
        public object UpdateSubject(Guid Id, UpdateSubject updateSubject)
        {

            var obj = dbContext.Subjects.Find(Id);
            int len = obj == null ? 0 : 1;
            Models.Response response = new Models.Response();
            if (len == 0)
            {
                response.Data = obj;
                response.StatusCode = 404;
                response.Message = "Not Found";
                return response;
            }
            if (updateSubject.SubjectName != "string") { obj.SubjectName = updateSubject.SubjectName; }

            dbContext.SaveChanges();

            if (len == 1)
            {
                response.Data = obj;
                response.StatusCode = 200;
                response.Message = "Subject Name updated";
            }
            return response;
        }
    }
}
