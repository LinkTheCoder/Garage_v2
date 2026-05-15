/// <summary>
/// Interface för GarageHandler. Definierar de operationer som UI-lagret behöver ha tillgång till.
/// </summary>
namespace Garage
{
    internal interface IHandler
    {
        void CreateGarage(int capacity);
        bool AddVehicle(IVehicle vehicle);
        bool RemoveVehicle(string registrationNumber);
        IVehicle? FindVehicle(string registrationNumber);
        IEnumerable<IVehicle> GetAllVehicles();
        IVehicle[] SearchVehicles(Func<IVehicle, bool> predicate);
        IEnumerable<(string TypeName, int Count)> GetVehicleTypeCounts();
        bool ContainsVehicle(string registrationNumber);
        int Count { get; }
        int Capacity { get; }
        bool IsFull { get; }
    }
}
