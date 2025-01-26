using System.Net;

namespace AcerteOGrid.Exception.ExceptionsBase
{
    public class NotFoundException : AcerteOGridException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
