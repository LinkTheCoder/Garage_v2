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
            IHandler handler = new GarageHandler();
            IUI ui = new GarageUI(handler);
            ui.Run();
        }
    }
}
