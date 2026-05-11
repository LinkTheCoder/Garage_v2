/// <summary>
/// Startpunkt för appliktionen.
/// Kallar på GarageUI.cs för att köra användargränssnittet.
/// </summary>

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new GarageUI().Run();
        }
    }
}
