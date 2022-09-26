using Data.Abstract;
using Data.Concrete.EntityFramework.Conctext;
using Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly DataContext _context;
        private EfStudentRepository _studentRepository;
        private EfLessonRepository _lessonRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            
        }

        public IStudentRepository Student => _studentRepository ?? new EfStudentRepository(_context);

        public ILessonRepository Lesson => _lessonRepository ?? new EfLessonRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
