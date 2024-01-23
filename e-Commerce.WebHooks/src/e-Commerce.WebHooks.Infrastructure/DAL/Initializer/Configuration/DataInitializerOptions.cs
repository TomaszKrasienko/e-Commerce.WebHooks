namespace e_Commerce.WebHooks.Infrastructure.DAL.Initializer.Configuration;

public record DataInitializerOptions
{
    public bool Enabled { get; init; }
    public bool FromFile { get; init; }
    public string Path { get; set; }
}