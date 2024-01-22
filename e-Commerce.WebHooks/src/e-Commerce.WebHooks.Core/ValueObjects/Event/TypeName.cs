using e_Commerce.WebHooks.Core.Exceptions;

namespace e_Commerce.WebHooks.Core.ValueObjects.Event;

public record TypeName
{
    public string Value { get; private init; }

    public TypeName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidTypeNameException();
        }
        Value = value;
    }

    public static implicit operator string(TypeName typeName)
        => typeName.Value;

    public static implicit operator TypeName(string value)
        => new TypeName(value);
}