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
    public class LessonManager:ILessonService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IMapper _mapper;

        public LessonManager(IUnitOfWorks unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var category = await _unitOfWork.Lesson.GetLesson(id);
            if (category != null)
            {
                await _unitOfWork.Lesson.Delete(category);

            }
            else
            {
                throw new ValidationException("lesson bulunamadı");
            }

            return true;
        }

        public async Task<List<GetListLessonDto>> GetAllLesson()
        {
            var a = await _unitOfWork.Lesson.GetAll();
            var list = _mapper.Map<List<GetListLessonDto>>(a);


            return list;
        }

        public async Task<List<GetLessonDto>> GetLessonID(int id)
        {
            var category = await _unitOfWork.Lesson.GetLessonId(id);
            var list = _mapper.Map<List<GetLessonDto>>(category);
            return list;
        }

        public async Task<List<GetStudentDto>> GetStudents(string searchTerm)
        {


            var a = _mapper.Map<List<GetStudentDto>>(await _unitOfWork.Student.GetStudents(searchTerm));


            return a;
        }

        public async Task<List<GetLessonDto>> GetLessons(string searchTerm)
        {
            var a = _mapper.Map<List<GetLessonDto>>(await _unitOfWork.Lesson.GetLesson(searchTerm));


            return a;
        }

        public async Task<GetLessonDto> Post(CreateLessonDto createLessonDto)
        {
            var category = _mapper.Map<Lesson>(createLessonDto);
            var existingCat = await _unitOfWork.Lesson.LessonExists(createLessonDto.Name);


            await _unitOfWork.Lesson.AddLesson(category);
            var categoryForGetDto = _mapper.Map<GetLessonDto>(category);


            return categoryForGetDto;
        }

        public async Task<UpdateLessonDto> Update(UpdateLessonDto updateLessonDto, int id)
        {
            var ownerEntity = await _unitOfWork.Lesson.GetLesson(id);
            _mapper.Map<GetLessonDto>(ownerEntity);
            _mapper.Map(updateLessonDto, ownerEntity);
            await _unitOfWork.Lesson.Update(ownerEntity, id);

            return updateLessonDto;
        }

       
    
    }
}
