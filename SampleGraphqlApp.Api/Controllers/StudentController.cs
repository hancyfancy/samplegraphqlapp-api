using Microsoft.AspNetCore.Mvc;
using SampleGraphqlApp.Api.Models;
using SampleGraphqlApp.Data.Interface.Models.Complete;
using SampleGraphqlApp.Service.Interface.Services;

namespace SampleGraphqlApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "BookAndCollegeDetails")]
        public async Task<ActionResult<BookAndCollegeDetails>> BookAndCollegeDetails([FromBody] BookAndCollegeQuery query)
        {
            IEnumerable<Book>? books = await _studentService.GetAvailableBooks(query.studentFirstName);

            College? college = await _studentService.GetEnrolledCollege(query.studentId);

            return Ok(new BookAndCollegeDetails() { 
                bookDetails = new BookDetails() { 
                    studentFirstName = query.studentFirstName,
                    books = books.ToList()
                },
                collegeDetails = new CollegeDetails() { 
                    studentId = query.studentId,
                    college = college
                }
            });
        }

        [HttpGet(Name = "Students")]
        public async Task<ActionResult<IEnumerable<Student>>> Students()
        {
            IEnumerable<Student>? students = await _studentService.GetAllStudents();

            return Ok(students);
        }
    }
}