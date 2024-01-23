using System.Reflection;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;
using e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;
using e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;
using e_Commerce.WebHooks.Infrastructure.Validation.Decorators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.Validation.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddValidation(this IServiceCollection services)
        => services
            .AddValidators()
            .AddDecorator();

    private static IServiceCollection AddValidators(this IServiceCollection services)
        => services
            .AddScoped<IValidator<AddEventCommand>, AddEventCommandValidator>()
            .AddScoped<IValidator<AddAddressCommand>, AddAddressCommandValidator>()
            .AddScoped<IValidator<DeleteAddressCommand>, DeleteAddressCommandValidator>()
            .AddScoped<IValidator<DispatchEventCommand>, DispatchEventCommandValidator>();

    private static IServiceCollection AddDecorator(this IServiceCollection services)
    {
        services.TryDecorate(typeof(INotificationHandler<>), typeof(CommandHandlerValidationDecorator<>));
        return services;
    }
}