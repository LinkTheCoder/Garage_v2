/// <summary>
/// Interface för ett fordon. Definierar de gemensamma egenskaper som alla fordon har.
/// </summary>
namespace Garage
{
    internal interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
    }
}
