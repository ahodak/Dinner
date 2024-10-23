using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.DinnerAggregate.Entities;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.HostAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.ValueObjects;

namespace Dinner.Domain.DinnerAggregate;

/// <summary>
/// Званный ужин
/// </summary>
public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new ();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public string Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Money Price { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public string ImageUrl { get; private set; }
    public Location Location { get; private set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Dinner()
    {
    }
#pragma warning restore CS8618

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        Money price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        Money price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new (
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            null,
            null,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
