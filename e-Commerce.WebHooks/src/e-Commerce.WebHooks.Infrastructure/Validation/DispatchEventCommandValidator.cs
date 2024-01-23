using e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;
using FluentValidation;

namespace e_Commerce.WebHooks.Infrastructure.Validation;

internal sealed class DispatchEventCommandValidator : AbstractValidator<DispatchEventCommand>
{
    public DispatchEventCommandValidator()
    {
        RuleFor(x => x.EventNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event number can not be null or empty");
        RuleFor(x => x.EventTypeName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event type name can not be null or empty");
    }
}