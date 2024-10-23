using Dinner.Domain.UserAggregate;

namespace Dinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    /// <summary>
    /// Сгенерировать JWT-токен безопасности
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <returns>Возвращает строку со значением токена</returns>
    string GenerateToken(User user);
}
