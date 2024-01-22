namespace e_Commerce.WebHooks.Infrastructure.WebHooksDispatcher.Configuration;

public record WebHooksOptions
{
    public int Retries { get; init; }
    public TimeSpan TimeOut { get; init; }
}