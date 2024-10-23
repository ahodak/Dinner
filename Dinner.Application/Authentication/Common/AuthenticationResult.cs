using Dinner.Domain.UserAggregate;

namespace Dinner.Application.Authentication.Common;

/// <summary>
/// Результат авторизации пользователя в приложении
/// </summary>
/// <param name="User">Пользователь</param>
/// <param name="Token">JWT-токен доступа</param>
public record AuthenticationResult
(
    User User,
    string Token
);
