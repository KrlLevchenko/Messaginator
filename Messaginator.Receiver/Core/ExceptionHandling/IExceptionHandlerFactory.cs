using System;

namespace Messaginator.Receiver.Core.ExceptionHandling
{
	public interface IExceptionHandlerFactory
	{
		IExceptionHandler? GetForOrDefault(Type type);
	}
}