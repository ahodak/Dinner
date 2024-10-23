using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.HostAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.MenuAggregate.Events;
using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.MenuReviewAggregate.ValueObjects;

namespace Dinner.Domain.MenuAggregate;

/// <summary>
/// Меню
/// </summary>
public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public HostId HostId { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Menu()
    {
    }
#pragma warning restore CS8618

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        _sections = sections;
        AverageRating = AverageRating.CreateNew();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            sections,
            DateTime.UtcNow,
            DateTime.UtcNow);

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;
    }
}
