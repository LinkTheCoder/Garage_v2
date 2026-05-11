/// <summary>
/// En klass som representerar ett flygplan, som är en typ av fordon.
/// Registreringsnummer, färg och antal hjul ärvs från Vehicle-klassen
/// Samt flygplanet har dessutom en egenskap för antal motorer.
/// </summary>
namespace Garage
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string registrationNumber, string color, int numberOfEngines)
            : base(registrationNumber, color, numberOfWheels: 3)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString() =>
            base.ToString() + $", Engines: {NumberOfEngines}";
    }
}
