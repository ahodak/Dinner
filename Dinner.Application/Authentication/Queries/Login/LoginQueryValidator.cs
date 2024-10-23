using FluentValidation;

namespace Dinner.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    /// <summary>
    /// Проверяет правильность параметров запроса на вход в приложение
    /// </summary>
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
