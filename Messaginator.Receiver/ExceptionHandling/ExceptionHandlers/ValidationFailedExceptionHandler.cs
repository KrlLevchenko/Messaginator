using System.Threading.Tasks;
using Messaginator.Receiver.Core.ExceptionHandling;
using Messaginator.Receiver.ExceptionHandling.Exceptions;

namespace Messaginator.Receiver.ExceptionHandling.ExceptionHandlers
{
    public class ValidationFailedExceptionHandler: ExceptionHandlerBase<ValidationFailedException>
    {
        protected override Task<ExceptionHandleResult> HandleInternal(ValidationFailedException exception) => Task.FromResult(new ExceptionHandleResult(400, exception.Message));
    }
}