using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.HostAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.UserAggregate.ValueObjects;

namespace Dinner.Domain.HostAggregate;

/// <summary>
/// Хозяин
/// </summary>
public sealed class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImageUrl { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Host()
    {
    }
#pragma warning restore CS8618

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImageUrl,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        UserId = userId;
        AverageRating = AverageRating.CreateNew();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImageUrl,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImageUrl,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
