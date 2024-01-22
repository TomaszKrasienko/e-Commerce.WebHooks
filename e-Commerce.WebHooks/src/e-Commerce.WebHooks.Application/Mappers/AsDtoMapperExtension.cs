using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Core.Entities;

namespace e_Commerce.WebHooks.Application.Mappers;

internal static class AsDtoMapperExtensions
{
    public static EventDto AsDto(this Event @event)
        => new EventDto(@event.Id, @event.TypeName);
}