using System.Threading.Tasks;
using Messaginator.Receiver.Core.ExceptionHandling;
using Messaginator.Receiver.ExceptionHandling.Exceptions;

namespace Messaginator.Receiver.ExceptionHandling.ExceptionHandlers
{
    public class EntityNotFoundExceptionHandler: ExceptionHandlerBase<EntityNotFoundException>
    {
        protected override Task<ExceptionHandleResult> HandleInternal(EntityNotFoundException exception) => Task.FromResult(new ExceptionHandleResult(404, exception.Message));
    }
}