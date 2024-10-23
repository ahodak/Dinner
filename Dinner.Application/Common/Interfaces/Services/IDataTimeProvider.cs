namespace Dinner.Application.Common.Interfaces.Services;

public interface IDataTimeProvider
{
    DateTime UtcNow { get; }
}