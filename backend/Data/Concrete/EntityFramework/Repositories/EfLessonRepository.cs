using Data.Abstract;
using Data.Concrete.EntityFramework.Conctext;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Repositories
{
    public class EfLessonRepository : ILessonRepository
    {
        private readonly DataContext _context;

        public EfLessonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Lesson lesson)
        {
            await Task.Run(() => { _context.Set<Lesson>().Remove(lesson); });
            _context.SaveChanges();
        }

        public async Task<List<Lesson>> GetAll()
        {
            var category = await _context.Lessons.ToListAsync();
            return category;
        }

        public async Task<List<Lesson>> GetLesson(string searchTerm)
        {
            return await _context.Lessons.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public Task<Lesson> GetLesson(int id)
        {
            var category = _context.Lessons.FirstOrDefaultAsync(q => q.Id == id);
            return category;
        }

        public async Task<List<Lesson>> GetLessonId(int id)
        {
            return await _context.Lessons.Where(a => a.Id == id).ToListAsync();
        }

        public async Task<Lesson> LessonExists(string name)
        {
            var exist = await _context.Lessons.FirstOrDefaultAsync(a => a.Name.Trim() == name.Trim());
            return exist;
        }

        public async Task<Lesson> LessonExistsId(int id)
        {
            var exist = await _context.Lessons.FirstOrDefaultAsync(a => a.Id == id);
            return exist;
        }

        public Task<Lesson> Update(Lesson lesson, int id)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException("item");
            }

            var item = _context.Lessons.FirstOrDefaultAsync(q => q.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException("category");
            }
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
            return item;
        }
    

    }
}
