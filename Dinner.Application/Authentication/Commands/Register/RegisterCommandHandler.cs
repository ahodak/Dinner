using Dinner.Application.Authentication.Common;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Common.Errors;
using Dinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Обработчик команды регистрации пользователя в приложении
    /// </summary>
    /// <param name="command">Команда на регистрацию</param>
    /// <param name="cancellationToken">Токе отмены</param>
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Проверить, что пользователя ещё не существует
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Создать пользователя (сгнерировать уникальный ID)
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        // Сохранить в репозитории
        _userRepository.Add(user);

        // Создать JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
                user,
                token
            );
    }
}