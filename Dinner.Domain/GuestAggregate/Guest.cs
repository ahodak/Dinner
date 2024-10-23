using Dinner.Domain.BillAggregate.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.GuestAggregate.ValueObjects;
using Dinner.Domain.MenuReviewAggregate.ValueObjects;
using Dinner.Domain.UserAggregate.ValueObjects;

namespace Dinner.Domain.GuestAggregate;

/// <summary>
/// Гость
/// </summary>
public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new ();
    private readonly List<DinnerId> _pastDinnerIds = new ();
    private readonly List<DinnerId> _pendingDinnerIds = new ();
    private readonly List<BillId> _billIds = new ();
    private readonly List<MenuReviewId> _menuReviewIds = new ();
    private readonly List<Rating> _ratings = new ();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImageUrl { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Guest()
    {
    }
#pragma warning restore CS8618

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImageUrl,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        UserId = userId;
        AverageRating = AverageRating.CreateNew();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImageUrl,
        UserId userId)
    {
        return new (
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImageUrl,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
