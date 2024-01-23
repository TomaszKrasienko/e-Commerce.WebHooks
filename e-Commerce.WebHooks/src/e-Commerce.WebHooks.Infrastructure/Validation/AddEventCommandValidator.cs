using e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;
using FluentValidation;

namespace e_Commerce.WebHooks.Infrastructure.Validation;

internal sealed class AddEventCommandValidator : AbstractValidator<AddEventCommand>
{
    public AddEventCommandValidator()
    {
        RuleFor(x => x.TypeName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Type name can not be null or empty");
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id can not be empty");
    } 
}