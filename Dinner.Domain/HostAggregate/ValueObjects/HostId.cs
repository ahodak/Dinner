using Dinner.Domain.Common.Models;

namespace Dinner.Domain.HostAggregate.ValueObjects;

/// <summary>
/// Идентификатор хозяина ужина
/// </summary>
public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    public static HostId Create(string value)
    {
        return Create(new Guid(value));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
