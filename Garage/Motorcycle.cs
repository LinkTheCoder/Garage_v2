/// <summary>
/// En klass som representerar en motorcykel, som är en typ av fordon.
/// Registreringsnummer, färg och antal hjul ärvs från Vehicle-klassen
/// Samt motorcykeln har dessutom en egenskap för cylindervolym.
/// </summary>
namespace Garage
{
    internal class Motorcycle : Vehicle
    {
        public double CylinderVolume { get; set; }

        public Motorcycle(string registrationNumber, string color, double cylinderVolume)
            : base(registrationNumber, color, numberOfWheels: 2)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString() =>
            base.ToString() + $", Cylinder Volume: {CylinderVolume} cc";
    }
}
