using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public double Amount { get; private set; }
    public string Currency { get; private set; }

    public Money(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount.ToString() + Currency;
    }
}