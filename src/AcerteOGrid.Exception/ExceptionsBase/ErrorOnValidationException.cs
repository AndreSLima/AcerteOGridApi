namespace AcerteOGrid.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : AcerteOGridException
    {
        public List<string> Errors;

        public ErrorOnValidationException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
