using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface ITeacherService
    {
        public object AddTeacher(Teacher teacher);
        public object GetTeacher(Guid Id);
        public object DeleteTeacher(Guid Id);
        public object UpdateTeacher(Guid Id, UpdateTeacher updateTeacher);
    }
}
