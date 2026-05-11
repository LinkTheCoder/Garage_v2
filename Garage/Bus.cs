/// <summary>
/// En klass som representerar en buss, som är en typ av fordon.
/// Registreringsnummer, färg och antal hjul ärvs från Vehicle-klassen
/// Samt bussen har dessutom en egenskap för antal sittplatser.
/// </summary>
namespace Garage
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string registrationNumber, string color, int numberOfSeats)
            : base(registrationNumber, color, numberOfWheels: 4)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString() =>
            base.ToString() + $", Seats: {NumberOfSeats}";
    }
}
