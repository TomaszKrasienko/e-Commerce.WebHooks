namespace e_Commerce.WebHooks.Application.DTOs;

public record WebHookDto(string EventNumber, List<string> Addresses);