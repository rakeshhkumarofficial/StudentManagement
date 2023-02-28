using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Service;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly StudentManagementAPIDbContext dbContext;
        public TeacherController(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult AddTeachers(Teacher teacher)
        {
            TeacherService service = new TeacherService(dbContext);
            var res = service.AddTeacher(teacher);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult GetTeachers(Guid Id)
        {
            TeacherService service = new TeacherService(dbContext);
            var res = service.GetTeacher(Id);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteTeachers(Guid Id)
        {
            TeacherService service = new TeacherService(dbContext);
            var res = service.DeleteTeacher(Id);
            return Ok(res);
        }

        [HttpPut]
        public IActionResult PutTeachers(Guid Id, UpdateTeacher updateTeacher)
        {
            ITeacherService service = new TeacherService(dbContext);
            var res = service.UpdateTeacher(Id, updateTeacher);
            return Ok(res);
        }
    }
}
