using Entities.Concrete.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Validations
{
    public class CreateLessonValidator : AbstractValidator<CreateLessonDto>
    {
        public CreateLessonValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("name alanı boş bırakılamaz");
        }
    }
}
