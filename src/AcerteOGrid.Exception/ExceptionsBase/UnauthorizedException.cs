using System.Net;

namespace AcerteOGrid.Exception.ExceptionsBase
{
    public class UnauthorizedException : AcerteOGridException
    {
        public UnauthorizedException(string message): base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
