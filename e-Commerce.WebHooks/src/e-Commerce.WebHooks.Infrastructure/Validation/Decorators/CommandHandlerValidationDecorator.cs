using e_Commerce.WebHooks.Core.Exceptions.Base;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace e_Commerce.WebHooks.Infrastructure.Validation.Decorators;

internal sealed class CommandHandlerValidationDecorator<T> : INotificationHandler<T> where T : class, INotification
{
    private readonly IValidator<T> _validator;
    private readonly INotificationHandler<T> _handler;

    public CommandHandlerValidationDecorator(IValidator<T> validator, INotificationHandler<T> handler)
    {
        _validator = validator;
        _handler = handler;
    }
    
    public async Task Handle(T notification, CancellationToken cancellationToken)
    {
        if (_validator is not null)
        {
            var validationResult = _validator.Validate(notification);
            if (!validationResult.IsValid)
            {
                throw new CommandValidationException(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        await _handler.Handle(notification, cancellationToken);
    }
}

internal class CommandValidationException(List<string> errors)
    : CustomException(string.Join(";", errors));