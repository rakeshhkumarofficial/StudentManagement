using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface ITeacherService
    {
        public object AddTeacher(Teacher teacher);
        public object GetTeacher(Guid Id);
    }
}
