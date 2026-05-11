using System.Collections;

/// <summary>
/// Ett generisk garage klass som lagrar fordon i en privat array.
/// Använder enumerable för att kunna göra foreach-loopar över fordonen i garaget.
/// T ska vara en Vehicle (eller subklass av Vehicle).
/// </summary>
namespace Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private readonly T?[] _vehicles;
        private int _count;

        public int Capacity => _vehicles.Length;
        public int Count => _count;

        /// <summary>
        /// Kapaciteten (antal parkeringsplatser) måste anges när garaget skapas.
        /// </summary>
        public Garage(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            _vehicles = new T?[capacity];
        }

        /// <summary>
        /// Parkerar ett fordon. Returnerar false om garaget är fullt eller om registreringsnumret redan finns.
        /// </summary>
        public bool Add(T vehicle)
        {
            if (_count >= Capacity)
                return false;

            if (Contains(vehicle.RegistrationNumber))
                return false;

            _vehicles[_count] = vehicle;
            _count++;
            return true;
        }

        /// <summary>
        /// Tar bort ett fordon från garaget baserat på registreringsnumret. 
        /// Returnerar false om fordonet inte hittas.
        /// Fyller i gapet genom att flytta det sista fordonet till tomma platsen.
        /// </summary>
        public bool Remove(string registrationNumber)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_vehicles[i]!.RegistrationNumber == registrationNumber.ToUpper())
                {
                    _vehicles[i] = _vehicles[_count - 1];
                    _vehicles[_count - 1] = null;
                    _count--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hittar ett fordon baserat på registreringsnumret. Returnerar null om det inte hittas.    
        /// </summary>
        public T? Find(string registrationNumber)
        {
            string reg = registrationNumber.ToUpper();
            foreach (T vehicle in this)
            {
                if (vehicle.RegistrationNumber == reg)
                    return vehicle;
            }
            return null;
        }

        public bool Contains(string registrationNumber)
        {
            return Find(registrationNumber) != null;
        }

        /// <summary>
        /// Returnerar alla fordon som matchar det givna villkoret (predikat).
        /// Fyll sedan resultat arrayen med de matchande fordonen.
        /// </summary>
        public T[] FindAll(Func<T, bool> predicate)
        {

            int matchCount = 0;
            for (int i = 0; i < _count; i++)
            {
                if (predicate(_vehicles[i]!))
                    matchCount++;
            }

            T[] result = new T[matchCount];
            int index = 0;
            for (int i = 0; i < _count; i++)
            {
                if (predicate(_vehicles[i]!))
                {
                    result[index] = _vehicles[i]!;
                    index++;
                }
            }

            return result;
        }
        /// <summary>
        /// Tillåter foreach-loopar över garaget.
        /// Returnerar fordonen i den ordning de parkerades.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
                yield return _vehicles[i]!;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
