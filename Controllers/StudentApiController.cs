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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <IEnumerable<Student>> GetAllStudent()
        {
            if (StudentsDataSimulation.studentsList.Count==0)
            {
                return NotFound("No Student Found");
            }
            return Ok(StudentsDataSimulation.studentsList);
        }

        [HttpGet("Passed" ,Name = " GetPassedStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <IEnumerable<Student>> GetPassedStudent()
        {
            var PassedStudent = StudentsDataSimulation.studentsList.Where(Student => Student.Grade >= 10).ToList();

            if(PassedStudent.Count==0)
            {
                return NotFound("No Passed Students ");
            }
            return Ok(PassedStudent);
        }

        [HttpGet("AverageGrade",Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<double> GetAverageGrades()
        {
            if (StudentsDataSimulation.studentsList.Count==0)
            {
                return NotFound("No Student Found");
            }
            var Average = StudentsDataSimulation.studentsList.Average(Student => Student.Grade);
            return Ok(Average);
        }

        [HttpGet("{StudentId}", Name = "GetStudentById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentById(int StudentId)
        {
            if(StudentId < 1)
            {
                return BadRequest($"Not Accepted ID {StudentId}");
            }

            var Student = StudentsDataSimulation.studentsList.FirstOrDefault(Student => Student.Id == StudentId);
            if(Student==null)
            {
                return NotFound($"The Id {StudentId} Not Found");
            }
            return Ok(Student);
        }

        [HttpPost(Name ="AddStudent")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            if (newStudent==null || newStudent.Age<0 || string.IsNullOrEmpty(newStudent.Name) || newStudent.Grade < 0|| newStudent.Grade>20 )
            {
                return BadRequest($"Invalid student data");
            }
            newStudent.Id = StudentsDataSimulation.studentsList.Count > 0 ? StudentsDataSimulation.studentsList.Max(s => s.Id) + 1 : 1;
            StudentsDataSimulation.studentsList.Add(newStudent);
            return CreatedAtRoute("GetStudentById", new { StudentId = newStudent.Id }, newStudent);
        }
    }
}
