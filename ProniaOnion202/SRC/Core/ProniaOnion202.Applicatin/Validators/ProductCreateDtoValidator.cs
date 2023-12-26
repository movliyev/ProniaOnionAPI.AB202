using FluentValidation;
using ProniaOnion202.Applicatin.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Validators
{
    public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("NAme is important")
                .MaximumLength(100).WithMessage("Name may consist maximum 100 characters")
                .MinimumLength(2).WithMessage("Name must consist minimum 2 characters");
            RuleFor(x=>x.SKU).NotEmpty()
                .Must(s=>s.Length == 6).WithMessage("SKU must contaon only 6 characters");
            RuleFor(x => x.Price).Must(x => x >= 10 && x <= 999999.99m);
            RuleFor(x => x.CategoryId).Must(x => x > 0);
            RuleForEach(x=>x.Colorids).Must(x=>x > 0);
        }
    }
}
