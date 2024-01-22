using e_Commerce.WebHooks.Core.Exceptions;

namespace e_Commerce.WebHooks.Core.ValueObjects;

public sealed record EntityId
{
    public Guid Value { get; private init; }
    public EntityId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyEntityIdException();
        }
        Value = value;
    }
    
    public static implicit operator Guid(EntityId entityId)
        => entityId.Value;

    public static implicit operator EntityId(Guid value)
        => new EntityId(value);

}