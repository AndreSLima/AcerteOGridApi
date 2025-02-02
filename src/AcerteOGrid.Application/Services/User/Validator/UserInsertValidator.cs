using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Exception;
using FluentValidation;

namespace AcerteOGrid.Application.Services.User
{
    public class UserInsertValidator : AbstractValidator<UserInsertRequestJson>
    {
        public UserInsertValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.USE_NAME_EMPTY);
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceErrorMessages.USER_EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceErrorMessages.USER_EMAIL_INVALID);

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<UserInsertRequestJson>());
        }
    }
}
