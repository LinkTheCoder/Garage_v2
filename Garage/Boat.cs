/// <summary>
/// En klass som representerar en båt, som är en typ av fordon.
/// Registreringsnummer, färg och antal hjul ärvs från Vehicle-klassen
/// Samt båten har dessutom en egenskap för längd.
/// </summary>
namespace Garage
{
    internal class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(string registrationNumber, string color, double length)
            : base(registrationNumber, color, numberOfWheels: 0)
        {
            Length = length;
        }

        public override string ToString() =>
            base.ToString() + $", Length: {Length} m";
    }
}
