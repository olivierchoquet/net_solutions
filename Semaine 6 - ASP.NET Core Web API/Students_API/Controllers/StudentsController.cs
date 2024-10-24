using Microsoft.AspNetCore.Mvc;
using Students_API.Models;

namespace Students_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentsController : ControllerBase
    {

        private static List<Student> _students = new List<Student>()
            {
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
            new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
            new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
            };

        /**
         * NE PAS METTRE  de [HttpGet name="GetAllStudents"] -> ceci sert a creer des URL specifiques !!!
         * 
         * [HttpGet("GetAllStudents") est par contre correct !!!
         * 
         **/


        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {

            return _students;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student student = _students.FirstOrDefault((c) => c.Id == id);
            if (student == null) return NotFound();
            return student;

        }


        [HttpPost]
        public bool AddStudent([FromBody] Student student)
        {
            if (_students.Contains(student)) return false;
            _students.Add(student);
            return true;
        }

    }
}

