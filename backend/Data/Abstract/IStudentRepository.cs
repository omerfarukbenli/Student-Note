using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<List<Student>> GetStudents(string searchTerm);
        Task<List<Student>> GetStudentId(int id);
        Task<Student> StudentExists(string name);
        Task<Student> Update(Student student, int id);
        Task<Student> StudentExistsId(int id);
        Task<Student> GetStudent(int id);
        Task Delete(Student student);
        Task<List<Student>> GetAll();
    }
}
