using ErrorOr;

namespace Dinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Пользователь с такмим email уже существует."
        );
    }
}
