using Dinner.Domain.Common.Models;

namespace Dinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Price : ValueObject
{
    public decimal Value { get; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}