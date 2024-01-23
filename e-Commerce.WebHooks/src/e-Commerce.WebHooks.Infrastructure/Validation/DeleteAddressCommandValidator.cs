using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;
using FluentValidation;

namespace e_Commerce.WebHooks.Infrastructure.Validation;

internal sealed class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id can not be empty");
    }
}