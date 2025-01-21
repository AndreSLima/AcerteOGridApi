using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Exception.ExceptionsBase;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotRegisterService
    {
        public ResponseRegisterPilotJson Execute(ResquestRegisterPilotJson request)
        {
            Validate(request);

            return new ResponseRegisterPilotJson();
        }

        private void Validate(ResquestRegisterPilotJson request)
        {
            var validator = new PilotRegisterValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(p => p.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
