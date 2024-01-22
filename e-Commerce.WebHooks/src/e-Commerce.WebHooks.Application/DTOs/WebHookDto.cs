namespace e_Commerce.WebHooks.Application.DTOs;

public record WebHookDto(string EventNumber, string EventTypeName, List<string> Addresses);