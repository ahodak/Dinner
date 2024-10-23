using Dinner.Domain.Common.Models;

namespace Dinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    private Location(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name + Address + Latitude + Longitude;
    }
}
