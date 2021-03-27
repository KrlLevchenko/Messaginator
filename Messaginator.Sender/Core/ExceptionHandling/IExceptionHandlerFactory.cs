using System;

namespace Messaginator.Sender.Core.ExceptionHandling
{
	public interface IExceptionHandlerFactory
	{
		IExceptionHandler? GetForOrDefault(Type type);
	}
}