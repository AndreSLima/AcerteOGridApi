namespace AcerteOGrid.Exception.ExceptionsBase
{
    public abstract class AcerteOGridException: SystemException
    {
        protected AcerteOGridException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
