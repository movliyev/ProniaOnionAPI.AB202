using FluentValidation;
using ProniaOnion202.Applicatin.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Validators
{
    public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().MaximumLength(50).MinimumLength(3).Matches(@"^[a-zA-Z\s]*$");
        }
    }
}
