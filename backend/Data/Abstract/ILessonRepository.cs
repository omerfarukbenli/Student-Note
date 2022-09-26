using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface ILessonRepository
    {
        Task AddLesson(Lesson lesson);
        Task<List<Lesson>> GetLesson(string searchTerm);
        Task<List<Lesson>> GetLessonId(int id);
        Task<Lesson> LessonExists(string name);
        Task<Lesson> Update(Lesson lesson, int id);
        Task<Lesson> LessonExistsId(int id);
        Task<Lesson> GetLesson(int id);
        Task Delete(Lesson lesson);
        Task<List<Lesson>> GetAll();
    }
}
