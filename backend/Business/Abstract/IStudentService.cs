using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        Task<List<GetStudentDto>>  GetStudents(string searchTerm);
        Task<GetStudentDto> Post(CreateStudentDto createStudentDto);
        Task<List<GetStudentDto>> GetStudentID(int id);
        Task<UpdateStudentDto> Update(UpdateStudentDto updateStudent, int id);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<GetListStudent>> GetAllStudent();
    }
}
