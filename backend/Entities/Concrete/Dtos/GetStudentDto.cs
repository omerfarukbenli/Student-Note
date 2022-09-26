using Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class GetStudentDto : DtoBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public int MidTermExam { get; set; }
        public int FinalExam { get; set; }
        public int LessonId { get; set; }
    }
}
