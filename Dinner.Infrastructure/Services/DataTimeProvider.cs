using Dinner.Application.Common.Interfaces.Services;

namespace Dinner.Infrastructure.Services;

public class DataTimeProvider : IDataTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}