namespace Dinner.Contracts.Authentication;

/// <summary>
/// Запрос на регистрацию пользователя в приложении
/// </summary>
/// <param name="FirstName">Имя</param>
/// <param name="LastName">фамилия</param>
/// <param name="Email">Адрес электронной почты</param>
/// <param name="Password">Пароль</param>
public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password
);
