using System.Text;
using Dinner.Application.Common.Interfaces.Authentication;
using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Application.Common.Interfaces.Services;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Persistence;
using Dinner.Infrastructure.Persistence.Interceptors;
using Dinner.Infrastructure.Persistence.Repositories;
using Dinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Dinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
        )
    {
        services
            .AddAuth(configuration)
            .AddPersistance()
            .AddSingleton<IDataTimeProvider, DataTimeProvider>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        // Чтение данных из файла настроек
        services.AddSingleton(Options.Create(jwtSettings));

        // Добавление генератора JWT-токенов
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                }
            );

        return services;
    }

    public static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddDbContext<DinnerDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=Dinner;User Id=sa;Password=ufkz30Dio;Encrypt=false"));

        // Добавить перехватчик публикации доменных событий
        services.AddScoped<PublishDomainEventsInterceptor>();

        // Добавление репозитория Пользователь
        services.AddScoped<IUserRepository, UserRepository>();

        // Добавление репозитория Меню
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }
}
