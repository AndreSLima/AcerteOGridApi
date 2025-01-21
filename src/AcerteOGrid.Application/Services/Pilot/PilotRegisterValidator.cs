using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Exception;
using FluentValidation;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotRegisterValidator : AbstractValidator<ResquestRegisterPilotJson>
    {
        public PilotRegisterValidator()
        {
            RuleFor(pilot => pilot.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
            RuleFor(pilot => pilot.ShortName).NotEmpty().WithMessage(ResourceErrorMessages.SHORT_NAME_REQUIRED);
            RuleFor(pilot => pilot.GenderType).IsInEnum().WithMessage(ResourceErrorMessages.GENDER_TYPE_INVALID);

            RuleFor(pilot => pilot.DateOfBirth).SetValidator(new DateValidator<ResquestRegisterPilotJson>());
        }
    }
}
