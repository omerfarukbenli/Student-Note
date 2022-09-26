using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUnitOfWorks : IAsyncDisposable
    {
        IStudentRepository Student { get; }
        ILessonRepository Lesson { get; }
        Task<int> SaveAsync();
    }
}

