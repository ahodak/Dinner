namespace Dinner.Contracts.Authentication;

/// <summary>
/// Ответ на запрос аутентификации пользователя
/// </summary>
/// <param name="Id">Уникальный идентификатор пользователя</param>
/// <param name="FirstName">Имя</param>
/// <param name="LastName">Фамилия</param>
/// <param name="Email">Адрес электронной почты</param>
/// <param name="Token">JWT-токен безопасности</param>
public record AuthenticationResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
