using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface IStudentService
    {
        public object AddStudent(Student student);
        public object GetStudent(Guid Id);
        public object DeleteStudent(Guid Id);
        public object UpdateStudent(Guid Id, UpdateStudent updateStudent);
    }
}
