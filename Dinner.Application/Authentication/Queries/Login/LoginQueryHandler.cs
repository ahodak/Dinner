using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Common.Errors;
using Dinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Queries;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Обработчик запроса на вход пользователя в приложение.
    /// </summary>
    /// <param name="query">Параметры запроса на вход в приложение.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Проверить, что пользователь существует
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Проверить, что пароль верный
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Создать JWT-token
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Вернуть результат проверки прарметров запроса на вход
        return new AuthenticationResult(
            user,
            token);
    }
}
