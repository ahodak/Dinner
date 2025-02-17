using Dinner.Domain.UserAggregate;

namespace Dinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}