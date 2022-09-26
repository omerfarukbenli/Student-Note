using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILessonService
    {
        Task<List<GetLessonDto>> GetLessons(string searchTerm);
        Task<GetLessonDto> Post(CreateLessonDto createLessonDto);
        Task<List<GetLessonDto>> GetLessonID(int id);
        Task<UpdateLessonDto> Update(UpdateLessonDto updateLessonDto, int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<GetListLessonDto>> GetAllLesson();
    }
}
