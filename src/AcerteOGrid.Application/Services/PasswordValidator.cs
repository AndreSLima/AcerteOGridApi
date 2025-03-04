﻿using AcerteOGrid.Exception;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Primitives;
using System.Text.RegularExpressions;

namespace AcerteOGrid.Application.Services
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (!Regex.IsMatch(password, @"[A-Z]+"))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (!Regex.IsMatch(password, @"[a-z]+"))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (!Regex.IsMatch(password, @"[0-9]+"))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (!Regex.IsMatch(password, @"[\!\?\*\.\@]+"))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            return true;
        }
    }
}
