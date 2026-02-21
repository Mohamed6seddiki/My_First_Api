using Api_Project.Models;
namespace Api_Project.DataStudents
{
    public class StudentsDataSimulation
    {
        public static readonly List<Student> studentsList = new List<Student>
        {
            new Student {Id = 1 ,Name = "mohamed" , Age =19 , Grade =9},
            new Student {Id = 2 ,Name = "mili" , Age =19 , Grade =7},
            new Student {Id = 3 ,Name = "seddiki" , Age =22 , Grade =20},
            new Student {Id = 4 ,Name = "ali" , Age =24 , Grade =4},
        };
    }
}
