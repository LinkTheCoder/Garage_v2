/// <summary>
/// En klass som representerar en bil, som är en typ av fordon.
/// Registreringsnummer, färg och antal hjul ärvs från Vehicle-klassen
/// Samt bilen har dessutom en egenskap för bränsletyp.
/// </summary>
namespace Garage
{
    internal enum FuelType { Gasoline, Diesel, Electric, Hybrid }

    internal class Car : Vehicle
    {
        public FuelType FuelType { get; set; }

        public Car(string registrationNumber, string color, FuelType fuelType)
            : base(registrationNumber, color, numberOfWheels: 4)
        {
            FuelType = fuelType;
        }

        public override string ToString() =>
            base.ToString() + $", Fuel: {FuelType}";
    }
}
