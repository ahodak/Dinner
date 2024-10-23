using Dinner.Domain.BillAggregate.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.GuestAggregate.ValueObjects;

namespace Dinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; private set; }
    public string Status { get; private set; } // PendingGuestConfirmation, Reserved, Cancelled
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime? ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Reservation()
    {
    }
#pragma warning restore CS8618

    private Reservation(ReservationId reservationId,
                        int guestCount,
                        string status,
                        GuestId guestId,
                        BillId billId,
                        DateTime? arrivalDateTime,
                        DateTime createdDateTime,
                        DateTime updatedDateTime)
        : base(reservationId)
    {
        GuestCount = guestCount;
        Status = status;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
                        int guestCount,
                        string status,
                        GuestId guestId,
                        BillId billId)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            status,
            guestId,
            billId,
            null,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
