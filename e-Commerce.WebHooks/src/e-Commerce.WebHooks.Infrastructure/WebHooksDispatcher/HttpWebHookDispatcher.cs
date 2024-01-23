using System.Net.Http.Json;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Services;
using Microsoft.Extensions.Logging;
using Extensions = e_Commerce.WebHooks.Infrastructure.WebHooksDispatcher.Configuration.Extensions;

namespace e_Commerce.WebHooks.Infrastructure.WebHooksDispatcher;

internal sealed class HttpWebHookDispatcher : IWebHookDispatcher
{
    private readonly ILogger<HttpWebHookDispatcher> _logger;
    private readonly HttpClient _client;

    public HttpWebHookDispatcher(ILogger<HttpWebHookDispatcher> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _client = httpClientFactory.CreateClient(Extensions.WebHookClient);
    }
    
    public async Task Send(WebHookDto dto, List<string> addresses, CancellationToken cancellationToken)
    {
        var tasks = new List<Task>();
        foreach (var address in addresses)
        {
            var task = HandleOne(dto, address, cancellationToken);
            tasks.Add(task);
        }
        await Task.WhenAll(tasks);
    }

    private async Task HandleOne(WebHookDto dto, string address, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(address, dto, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Successfully sent to address {address}");
            }
            else
            {
                _logger.LogWarning($"There was a problem with sending to address {address}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }
}