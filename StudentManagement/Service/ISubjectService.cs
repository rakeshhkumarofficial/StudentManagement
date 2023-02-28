using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface ISubjectService
    {
        public object AddSubject(Subject subject);
        public object GetSubject();
    }
}
