using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Commands.Register;

/// <summary>
/// Команда регистрации пользователя в приложении
/// </summary>
/// <param name="FirstName">Имя</param>
/// <param name="LastName">Фамилия</param>
/// <param name="Email">Адрес электронной почты</param>
/// <param name="Password">Пароль</param>
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
