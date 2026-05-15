/// <summary>
/// Hanterar all logik mellan UI-lagret och Garage-klassen.
/// Abstraherar bort direkt kontakt mellan GarageUI och Garage.
/// </summary>
namespace Garage
{
    internal class GarageHandler : IHandler
    {
        private Garage<IVehicle>? _garage;

        public int Count => _garage?.Count ?? 0;
        public int Capacity => _garage?.Capacity ?? 0;
        public bool IsFull => _garage != null && _garage.Count >= _garage.Capacity;

        /// <summary>
        /// Skapar ett nytt garage med angiven kapacitet.
        /// </summary>
        public void CreateGarage(int capacity)
        {
            _garage = new Garage<IVehicle>(capacity);
        }

        /// <summary>
        /// Parkerar ett fordon i garaget. Returnerar false om garaget är fullt eller reg.nr redan finns.
        /// </summary>
        public bool AddVehicle(IVehicle vehicle)
        {
            if (_garage is null) return false;
            return _garage.Add(vehicle);
        }

        /// <summary>
        /// Tar bort ett fordon baserat på registreringsnummer. Returnerar false om det inte hittas.
        /// </summary>
        public bool RemoveVehicle(string registrationNumber)
        {
            if (_garage is null) return false;
            return _garage.Remove(registrationNumber);
        }

        /// <summary>
        /// Hittar ett fordon baserat på registreringsnummer. Returnerar null om det inte hittas.
        /// </summary>
        public IVehicle? FindVehicle(string registrationNumber)
        {
            return _garage?.Find(registrationNumber);
        }

        /// <summary>
        /// Returnerar alla fordon i garaget.
        /// </summary>
        public IEnumerable<IVehicle> GetAllVehicles()
        {
            return _garage ?? (IEnumerable<IVehicle>)Array.Empty<IVehicle>();
        }

        /// <summary>
        /// Returnerar alla fordon som matchar det givna predikatet.
        /// </summary>
        public IVehicle[] SearchVehicles(Func<IVehicle, bool> predicate)
        {
            if (_garage is null) return Array.Empty<IVehicle>();
            return _garage.FindAll(predicate);
        }

        /// <summary>
        /// Returnerar varje fordonstyp och hur många av den typen som är parkerade.
        /// </summary>
        public IEnumerable<(string TypeName, int Count)> GetVehicleTypeCounts()
        {
            if (_garage is null) yield break;

            var counts = new Dictionary<string, int>();
            foreach (var v in _garage)
            {
                string typeName = v.GetType().Name;
                if (!counts.ContainsKey(typeName))
                    counts[typeName] = 0;
                counts[typeName]++;
            }
            foreach (var entry in counts)
                yield return (entry.Key, entry.Value);
        }

        /// <summary>
        /// Kontrollerar om ett fordon med angivet registreringsnummer redan finns i garaget.
        /// </summary>
        public bool ContainsVehicle(string registrationNumber)
        {
            return _garage?.Contains(registrationNumber) ?? false;
        }
    }
}
