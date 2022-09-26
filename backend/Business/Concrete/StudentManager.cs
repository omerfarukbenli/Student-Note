using AutoMapper;
using Business.Abstract;
using Data.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager:IStudentService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IMapper _mapper;

        public StudentManager(IUnitOfWorks unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
          
            
                var category = await _unitOfWork.Student.GetStudent(id);
                if (category != null)
                {
                    await _unitOfWork.Student.Delete(category);

                }
                else
                {
                    throw new ValidationException("Student bulunamadı");
                }
               
               return true;
            }
           

               
            
        

        public async Task<List<GetListStudent>> GetAllStudent()
        {
       
            var a = await _unitOfWork.Student.GetAll();
            var list = _mapper.Map<List<GetListStudent>>(a);
           

            return list;
     
        
    }

        public async Task<List<GetStudentDto>> GetStudentID(int id)
        {
        var category = await _unitOfWork.Student.GetStudentId(id);
        var list = _mapper.Map<List<GetStudentDto>>(category);
        return list;
    }

        public async Task<List<GetStudentDto>> GetStudents(string searchTerm)
        {
           
                
                var a = _mapper.Map<List<GetStudentDto>>(await _unitOfWork.Student.GetStudents(searchTerm));
             
               
                return a;
            }
            

        public async Task<GetStudentDto> Post(CreateStudentDto createStudentDto)
        {
           
                var category = _mapper.Map<Student>(createStudentDto);
                var existingCat = await _unitOfWork.Student.StudentExists(createStudentDto.Name);

            
                await _unitOfWork.Student.AddStudent(category);
                var categoryForGetDto = _mapper.Map<GetStudentDto>(category);
               
              
              return categoryForGetDto;
          

            
        }

        public async Task<UpdateStudentDto> Update(UpdateStudentDto updateStudent, int id)
        {
           
                var ownerEntity = await _unitOfWork.Student.GetStudent(id);
                _mapper.Map<GetStudentDto>(ownerEntity);
                _mapper.Map(updateStudent, ownerEntity);
                await _unitOfWork.Student.Update(ownerEntity, id);
            
                return updateStudent;


           
        }
    }
}
