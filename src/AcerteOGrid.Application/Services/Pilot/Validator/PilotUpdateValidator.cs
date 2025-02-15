using AcerteOGrid.Communication.Pilot;
using AcerteOGrid.Exception;
using FluentValidation;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotUpdateValidator : AbstractValidator<PilotRequestUpdate>
    {
        public PilotUpdateValidator()
        {
            RuleFor(pilot => pilot.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED);
            RuleFor(pilot => pilot.ShortName).NotEmpty().WithMessage(ResourceErrorMessages.SHORT_NAME_REQUIRED);
        }
    }
}
