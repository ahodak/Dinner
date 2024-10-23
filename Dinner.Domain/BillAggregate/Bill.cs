using Dinner.Domain.BillAggregate.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.GuestAggregate.ValueObjects;
using Dinner.Domain.HostAggregate.ValueObjects;

namespace Dinner.Domain.BillAggregate;

/// <summary>
/// Счёт за ужин
/// </summary>
public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Bill()
    {
    }
#pragma warning restore CS8618

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Money price)
    {
        return new (
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
