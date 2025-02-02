using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Exception;
using FluentValidation;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotUpdateValidator : AbstractValidator<PilotUpdateRequestJson>
    {
        public PilotUpdateValidator()
        {
            RuleFor(pilot => pilot.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
            RuleFor(pilot => pilot.ShortName).NotEmpty().WithMessage(ResourceErrorMessages.SHORT_NAME_REQUIRED);
        }
    }
}
