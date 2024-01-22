using e_Commerce.WebHooks.Application.DTOs;

namespace e_Commerce.WebHooks.Application.Services;

public interface IWebHookDispatcher
{
    Task Send(WebHookDto dto);
}