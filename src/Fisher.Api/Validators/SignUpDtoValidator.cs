using Fisher.Core.Data.Dtos;
using FluentValidation;

namespace Fisher.Api.Validators
{
    public class SignUpDtoValidator:AbstractValidator<SignUpDto>
    {
        public SignUpDtoValidator()
        {
            RuleFor(s => s.Email).EmailAddress().NotEmpty();
            RuleFor(s => s.Password).Equal(s => s.ConfirmedPassword).NotEmpty();
            RuleFor(s => s.UserName).MinimumLength(7);
        }
    }
}