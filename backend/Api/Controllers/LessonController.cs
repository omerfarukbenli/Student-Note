using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpGet]
        public async Task<ActionResult> GetLessons([FromQuery] string searchTerm)
        {
            return Ok(await _lessonService.GetLessons(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLessonId(int id)
        {
            return Ok(await _lessonService.GetLessonID(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllLesson()
        {
            return Ok(await _lessonService.GetAllLesson());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLessonDto categoryDto)
        {
            return Ok(await _lessonService.Post(categoryDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLessonDto categoryDto)
        {

            return Ok(await _lessonService.Update(categoryDto, id));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _lessonService.DeleteByIdAsync(id));

        }
      
    }
}
