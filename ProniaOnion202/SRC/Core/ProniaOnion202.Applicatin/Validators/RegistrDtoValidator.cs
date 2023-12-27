using FluentValidation;
using ProniaOnion202.Applicatin.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Validators
{
    public class RegistrDtoValidator:AbstractValidator<RegistrDto>
    {
        public RegistrDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                 .Matches(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")
                 .MaximumLength(256).WithMessage("Email may consist maximum 100 characters");
            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
                .MinimumLength(8).WithMessage("Password must consist minimum 8 characters")
                .MaximumLength(100).WithMessage("Password may consist maximum 100 characters");
            RuleFor(x => x.UserName).NotEmpty()
                .MaximumLength(256).WithMessage("UserName may consist maximum 256 characters")
                .MinimumLength(4).WithMessage("UserName must consist minimum 4 characters");
            RuleFor(x => x.Name).NotEmpty()
                .Matches(@"^[a-zA-Z\s]*$")
                .MaximumLength(50).WithMessage("Name may consist maximum 50 characters")
                .MinimumLength(3).WithMessage("Name must consist minimum 3 characters");
            RuleFor(x => x.Surname).NotEmpty()
                .Matches(@"^[a-zA-Z\s]*$")
                .MaximumLength(50).WithMessage("Name may consist maximum 50 characters")
                .MinimumLength(3).WithMessage("Name must consist minimum 3 characters");
            RuleFor(x => x)
                .Must(x => x.ConfirmPassword == x.Password);

        }
    }
}
