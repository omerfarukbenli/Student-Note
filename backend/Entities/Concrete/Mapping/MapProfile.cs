using AutoMapper;
using Entities.Concrete.Dtos;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, GetListStudent>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();


            CreateMap<Lesson, CreateLessonDto>().ReverseMap();
            CreateMap<Lesson, GetListLessonDto>().ReverseMap();
            CreateMap<Lesson, GetLessonDto>().ReverseMap();
            CreateMap<Lesson, UpdateLessonDto>().ReverseMap();
        }
    }
}
