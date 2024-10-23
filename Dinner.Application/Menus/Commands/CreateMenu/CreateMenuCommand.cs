using Dinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<CreaateMenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record CreaateMenuSectionCommand(
    string Name,
    string Description,
    List<CreateMenuItemCommand> Items);

public record CreateMenuItemCommand(
    string Name,
    string Description);
