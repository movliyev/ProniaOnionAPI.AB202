using FluentValidation;
using ProniaOnion202.Applicatin.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Validators
{
    public class LoginDtoVaildator : AbstractValidator<LoginDto>
    {
        public LoginDtoVaildator()
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty()
                .MaximumLength(256).WithMessage("UserName Or Email may consist maximum 256 characters")
                .MinimumLength(4).WithMessage("UserName or Email must consist minimum 4 characters");
            RuleFor(x => x.Password)
               .NotEmpty()
               .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
               .MinimumLength(8).WithMessage("Password must consist minimum 8 characters")
               .MaximumLength(100).WithMessage("Password may consist maximum 100 characters");
        }
    }
}
