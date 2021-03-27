using System;
using System.Threading.Tasks;

namespace Messaginator.Sender.Core.ExceptionHandling
{
	public interface IExceptionHandler
	{
		Task<ExceptionHandleResult> Handle(Exception exception);
	}
}