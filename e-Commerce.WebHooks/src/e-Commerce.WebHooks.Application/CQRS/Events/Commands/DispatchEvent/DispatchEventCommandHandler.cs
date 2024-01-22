using e_Commerce.WebHooks.Application.Services;
using e_Commerce.WebHooks.Core.Repositories;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;

internal sealed class DispatchEventCommandHandler
{
    private readonly IEventRepository _eventRepository;
    private readonly IWebHookDispatcher _webHookDispatcher;

    public DispatchEventCommandHandler(IEventRepository eventRepository, IWebHookDispatcher webHookDispatcher)
    {
        _eventRepository = eventRepository;
        _webHookDispatcher = webHookDispatcher;
    }
}