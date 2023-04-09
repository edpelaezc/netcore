using System;
using Entities.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
	public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
        private readonly IEnumerable<IValidator<TRequest>> _validators;


		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
            _validators = validators;
		}

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators
                                    .Select(x => x.Validate(context))
                                    .SelectMany(x => x.Errors)
                                    .Where(x => x != null)
                                    .GroupBy
                                    (
                                        x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                                        x => x.ErrorMessage,
                                        (propertyName, errorMessages) => new
                                        {
                                            Key = propertyName,
                                            Values = errorMessages.Distinct().ToArray()
                                        }
                                    ).ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                throw new ValidationAppException(errorsDictionary);
            }

            return await next();
        }
    }
}

