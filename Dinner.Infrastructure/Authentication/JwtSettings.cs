namespace Dinner.Infrastructure.Authentication;

/// <summary>
/// Настройки генератора JWT-токена
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Название секции в файле конфигурации appsettings.json
    /// </summary>
    public const string SectionName = "JwtSettings";

    /// <summary>
    /// Закрытый ключ
    /// </summary>
    public string Secret { get; init; } = null!;

    /// <summary>
    /// Издатель токена
    /// </summary>
    public string Issuer { get; init; } = null!;

    /// <summary>
    /// Предполагаемый получатель токена или ресурс
    /// </summary>
    public string Audience { get; init; } = null!;

    /// <summary>
    /// Количество минут действия токена
    /// </summary>
    public int ExpireMinutes { get; init; }
}
