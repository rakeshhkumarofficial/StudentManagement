using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Service;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentManagementAPIDbContext dbContext;
        public SubjectController(StudentManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddSubjects(Subject subject)
        {
            ISubjectService service = new SubjectService(dbContext);
            var res = service.AddSubject(subject);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            ISubjectService service = new SubjectService(dbContext);
            var res = service.GetSubject();
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult DeleteSubject(Guid Id)
        {
            ISubjectService service = new SubjectService(dbContext);
            var res = service.DeleteSubject(Id);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult PutSubjects(Guid Id, UpdateSubject updateSubject)
        {
            ISubjectService service = new SubjectService(dbContext);
            var res = service.UpdateSubject(Id, updateSubject);
            return Ok(res);
        }

    }
}
