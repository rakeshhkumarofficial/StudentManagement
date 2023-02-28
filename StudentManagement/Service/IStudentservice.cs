using StudentManagement.Models;

namespace StudentManagement.Service
{
    public interface IStudentservice
    {
        public object AddStudent(Student student);
        public object GetStudent(Guid Id);
    }
}
