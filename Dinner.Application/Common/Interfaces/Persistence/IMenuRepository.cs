using Dinner.Domain.MenuAggregate;

namespace Dinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
