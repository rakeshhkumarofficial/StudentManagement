using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Service;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly StudentManagementAPIDbContext dbContext;

        public AdminController(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("Teacher")]
        public IActionResult AddTeachers(Teacher teacher)
        {
            TeacherService service = new TeacherService(dbContext);
            var res = service.AddTeacher(teacher);
            return Ok(res);
        }
        [HttpPost]
        [Route("Student")]
        public IActionResult AddStudents(Student student)
        {
            StudentService service = new StudentService(dbContext);
            var res = service.AddStudent(student);
            return Ok(res);
        }
        [HttpPost]
        [Route("Subject")]
        public IActionResult AddSubjects(Subject subject)
        {
            SubjectService service = new SubjectService(dbContext);
            var res = service.AddSubject(subject);
            return Ok(res);
        }

        [HttpGet]
        [Route("Student")]
        public IActionResult GetStudents(Guid Id) {
            StudentService service = new StudentService(dbContext);
            var res = service.GetStudent(Id);
            return Ok(res);
        }
        [HttpGet]
        [Route("Teacher")]
        public IActionResult GetTeachers(Guid Id)
        {
            TeacherService service = new TeacherService(dbContext);
            var res = service.GetTeacher(Id);
            return Ok(res);
        }
        [HttpGet]
        [Route("Subject")]
        public IActionResult GetSubjects()
        {
            SubjectService service= new SubjectService(dbContext);
            var res = service.GetSubject();
            return Ok(res);
        }
        
        [HttpDelete]
        [Route("Student")]
        public IActionResult DeleteStudents(Guid Id)
        {
            StudentService service = new StudentService(dbContext);
            var res = service.DeleteStudent(Id);
            return Ok(res);
        }
    }
}
