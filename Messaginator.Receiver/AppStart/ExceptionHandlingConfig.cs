using System;
using System.Linq;
using System.Reflection;
using Messaginator.Receiver.Core.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Messaginator.Receiver.AppStart
{
	public static class ExceptionHandlingConfig
	{
		public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionHandlingMiddleware>();
			return app;
		}
		
		public static IServiceCollection AddErrorHandling(this IServiceCollection services, Type assemblyType)
		{
			services.AddSingleton<IExceptionHandlerFactory, ExceptionHandlerFactory>();

			return services.RegisterHandlers(assemblyType.Assembly);
		}

		private static IServiceCollection RegisterHandlers(this IServiceCollection services, Assembly assembly)
		{
			foreach (var type in assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract))
			{
				var closedGeneric = type.GetClosedAbstractHandler();
				if (closedGeneric != null)
				{
					services.AddTransient(closedGeneric, type);
				}
			}

			return services;
		}

		private static Type GetClosedAbstractHandler(this Type toCheck)
		{
			var generic = typeof(ExceptionHandlerBase<>);

			while (toCheck != null && toCheck != typeof(object))
			{
				var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
				if (generic == cur)
				{
					return toCheck;
				}

				toCheck = toCheck.BaseType;
			}

			return null;
		}
	}
}
