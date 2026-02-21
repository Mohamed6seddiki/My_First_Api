using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Project.DataStudents;
using Api_Project.Models;

namespace Api_Project.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Students")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        [HttpGet("All",Name = "GetAllStudent")]

        public ActionResult <IEnumerable<Student>> GetAllStudent()
        {
            return Ok(StudentsDataSimulation.studentsList);
        }

        [HttpGet("Passed" ,Name = " GetPassedStudent")]
        public ActionResult <IEnumerable<Student>> GetPassedStudent()
        {
            var PassedStudent = StudentsDataSimulation.studentsList.Where(Student => Student.Grade >= 10).ToList();
            return Ok(PassedStudent);
        }
    }
}
