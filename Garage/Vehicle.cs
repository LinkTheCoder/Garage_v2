/// <summary>
/// En abstrakt klass som representerar ett fordon. 
/// Den innehåller gemensamma egenskaper som registreringsnummer, färg och antal hjul.
/// Dessa som ärvs av alla specifika fordonstyper (bil, motorcykel, buss, båt).
/// </summary>
namespace Garage
{
    internal abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber.ToUpper();
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString() =>
            $"[{GetType().Name}] Reg: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
    }
}
