using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface ISubjectService
    {
        public object AddSubject(Subject subject);
        public object GetSubject();
        public object DeleteSubject(Guid Id);
        public object UpdateSubject(Guid Id, UpdateSubject updateSubject);
    }
}
