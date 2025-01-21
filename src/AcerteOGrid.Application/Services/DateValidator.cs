using AcerteOGrid.Exception;
using FluentValidation;
using FluentValidation.Validators;

namespace AcerteOGrid.Application.Services
{
    public class DateValidator<T> : PropertyValidator<T, DateTime>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        public override string Name => "DateValidator";

        public override bool IsValid(ValidationContext<T> context, DateTime DateOfBirth)
        {
            var returnValue = true;
            var dateOfBirth = Convert.ToString(DateOfBirth);

            if (string.IsNullOrWhiteSpace(dateOfBirth))
            {
                returnValue = false;
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.DATE_REQUIRED);
            }

            if (DateTime.TryParse(dateOfBirth, out DateTime dateBirth))
            {
                returnValue = false;
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.DATE_INVALID);
            }

            return returnValue;
        }
    }
}
