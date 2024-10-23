using Dinner.Domain.Common.Models;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.HostAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.ValueObjects;

namespace Dinner.Domain.MenuAggregate.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public int Rating { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private GuestRating()
    {
    }
#pragma warning restore CS8618

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            createdDateTime,
            updatedDateTime);
    }
}
