using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Service;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class StudentController : ControllerBase
    {
        private readonly StudentManagementAPIDbContext dbContext;
        public StudentController(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult AddStudents(Student student)
        {
            IStudentService service = new StudentService(dbContext);
            var res = service.AddStudent(student);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetStudents(Guid Id)
        {
            IStudentService service = new StudentService(dbContext);
            var res = service.GetStudent(Id);
            return Ok(res);
        }

        [HttpDelete]
        public IActionResult DeleteStudents(Guid Id)
        {
            IStudentService service = new StudentService(dbContext);
            var res = service.DeleteStudent(Id);
            return Ok(res);
        }

        [HttpPut]
        public IActionResult PutStudents(Guid Id, UpdateStudent updateStudent)
        {
            IStudentService service = new StudentService(dbContext);
            var res = service.UpdateStudent(Id,updateStudent);
            return Ok(res);
        }


    }
}
