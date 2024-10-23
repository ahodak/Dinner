namespace Dinner.Contracts.Authentication;

/// <summary>
/// Запрос на вход пользователя в приложение
/// </summary>
/// <param name="Email">Адрес электронной почты</param>
/// <param name="Password">Пароль</param>
public record LoginRequest
(
    string Email,
    string Password
);
