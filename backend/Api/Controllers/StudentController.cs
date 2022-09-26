using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult> GetStudent([FromQuery] string searchTerm)
        {
            return Ok(await _studentService.GetStudents(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentId(int id)
        {
            return Ok(await _studentService.GetStudentID(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllStudent()
        {
            return Ok(await _studentService.GetAllStudent());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentDto categoryDto)
        {
            return Ok(await _studentService.Post(categoryDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDto categoryDto)
        {

            return Ok(await _studentService.Update(categoryDto, id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _studentService.DeleteByIdAsync(id));

        }
      
    }
}
