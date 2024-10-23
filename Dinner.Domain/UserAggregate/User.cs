using Dinner.Domain.Common.Models;
using Dinner.Domain.UserAggregate.ValueObjects;

namespace Dinner.Domain.UserAggregate;

/// <summary>
/// Сущность Пользователь
/// </summary>
public sealed class User : AggregateRoot<UserId, Guid>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Адрес электронной почты пользователя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Дата и время создания пользователя
    /// </summary>
    public DateTime CreatedDateTime { get; private set; }

    /// <summary>
    /// Дата и время последнего обновления пользователя
    /// </summary>
    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    public User()
    {
    }
#pragma warning restore CS8618

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
