using System;
using FluentValidation.Results;

namespace Messaginator.Receiver.ExceptionHandling.Exceptions
{
    public class ValidationFailedException: Exception
    {
        public ValidationResult Result { get; }

        public ValidationFailedException(ValidationResult result)
        {
            Result = result;
        }
    }
}