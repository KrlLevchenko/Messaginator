using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pushinator.Web.ExceptionHandling.Exceptions;

namespace Messaginator.Sender.Core
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IServiceProvider _serviceProvider;
        public ValidationBehavior(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken ct,
            RequestHandlerDelegate<TResponse> next)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<TRequest>>();
            var result = await validator.ValidateAsync(request, ct);
            if (!result.IsValid)
            {
                throw new ValidationFailedException(result);
            }
            return await next();
        }
    }
}