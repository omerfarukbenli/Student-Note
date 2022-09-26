using Entities.Concrete.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models
{
    public class Lesson:EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
