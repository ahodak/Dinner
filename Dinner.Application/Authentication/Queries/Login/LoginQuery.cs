using Dinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login;

/// <summary>
/// Параметры запроса на вход в приложение
/// </summary>
/// <param name="Email">Адрес электронной почты</param>
/// <param name="Password">Пароль</param>
/// <returns></returns>
public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
