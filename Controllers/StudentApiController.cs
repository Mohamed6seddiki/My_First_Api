using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Project.DataStudents;
using Api_Project.Models;

namespace Api_Project.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Student")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        [HttpGet("AllStudent",Name = "AllStudent")]

        public ActionResult <IEnumerable<Student>> GetAllStudent()
        {
            return Ok(StudentsDataSimulation.studentsList);
        }
    }
}
