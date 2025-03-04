﻿using System.Net;

namespace AcerteOGrid.Exception.ExceptionsBase
{
    public class InvalidLoginException : AcerteOGridException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
