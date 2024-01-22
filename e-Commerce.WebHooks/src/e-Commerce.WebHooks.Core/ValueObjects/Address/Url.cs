using e_Commerce.WebHooks.Core.Exceptions;

namespace e_Commerce.WebHooks.Core.ValueObjects.Address;

public sealed record Url
{
    public string Value { get; private init; }

    public Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyUrlException();
        }
        Value = value;
    }
    
    public static implicit operator string(Url url)
        => url.Value;

    public static implicit operator Url(string value)
        => new Url(value);
}