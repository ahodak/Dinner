using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// Идентификатор рейтинга гостя
/// </summary>
public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestRatingId Create(Guid value)
    {
        return new GuestRatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
