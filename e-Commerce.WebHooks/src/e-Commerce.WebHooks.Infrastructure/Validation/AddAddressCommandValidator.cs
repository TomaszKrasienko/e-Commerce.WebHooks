using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;
using FluentValidation;

namespace e_Commerce.WebHooks.Infrastructure.Validation;

public class AddAddressCommandValidator : AbstractValidator<AddAddressCommand>
{
    public AddAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id can not be empty");
        RuleFor(x => x.Url)
            .NotNull()
            .NotEmpty()
            .WithMessage("Url can not be null or empty");
        RuleFor(x => x.EventTypeName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event type name can not be null or empty");
    }
}