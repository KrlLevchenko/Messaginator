using System;
using System.Threading.Tasks;

namespace Messaginator.Receiver.Core.ExceptionHandling
{
	public interface IExceptionHandler
	{
		Task<ExceptionHandleResult> Handle(Exception exception);
	}
}