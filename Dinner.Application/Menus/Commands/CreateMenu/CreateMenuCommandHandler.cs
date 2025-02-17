using System.Reflection.PortableExecutable;

using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.HostAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate;
using Dinner.Domain.MenuAggregate.Entities;

using ErrorOr;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                name: section.Name,
                description: section.Description,
                items: section.Items.ConvertAll(item => MenuItem.Create(
                    name: item.Name,
                    description: item.Description
                ))
            ))
        );

        _menuRepository.Add(menu);

        return menu;
    }
}
