using Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class UpdateLessonDto : DtoBase
    {
        public string Name { get; set; }
    }
}
