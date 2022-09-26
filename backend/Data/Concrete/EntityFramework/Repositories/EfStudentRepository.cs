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
    public class EfStudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public EfStudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            await Task.Run(() => { _context.Set<Student>().Remove(student); });
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetAll()
        {
            var category = await _context.Students.ToListAsync();
            return category;
        }

        public Task<Student> GetStudent(int id)
        {
            var category = _context.Students.FirstOrDefaultAsync(q => q.Id == id);
            return category;
        }

        public async Task<List<Student>> GetStudentId(int id)
        {
            return await _context.Students.Where(a => a.Id == id).ToListAsync();
        }

        public async Task<List<Student>> GetStudents(string searchTerm)
        {
            return await _context.Students.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public async Task<Student> StudentExists(string name)
        {
            var exist = await _context.Students.FirstOrDefaultAsync(a => a.Name.Trim() == name.Trim());
            return exist;
        }

        public async Task<Student> StudentExistsId(int id)
        {
            var exist = await _context.Students.FirstOrDefaultAsync(a => a.Id == id);
            return exist;
        }

        public Task<Student> Update(Student student, int id)
        {
            if (student == null)
            {
                throw new ArgumentNullException("item");
            }

            var item = _context.Students.FirstOrDefaultAsync(q => q.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException("category");
            }
            _context.Students.Update(student);
            _context.SaveChanges();
            return item;
        }
    }
    
}
