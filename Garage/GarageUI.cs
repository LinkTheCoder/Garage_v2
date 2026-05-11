/// <summary>
/// Lagrar ett garage som kan innehålla Vehicle-objekt.
/// Garaget kan också vara null om inget garage har skapats än.
/// Visar en startmeny med olika alternativ.
/// </summary>
namespace Garage
{

    internal class GarageUI
    {
        private Garage<Vehicle>? _garage;

        public void Run()
        {
            Console.WriteLine("=== Garage Manager ===");
            InitGarage();
            bool running = true;
            while (running)
            {
                ShowMenu();
                switch (ReadOption())
                {
                    case 1: ListVehicles(); break;
                    case 2: AddVehicle(); break;
                    case 3: RemoveVehicle(); break;
                    case 4: FindVehicle(); break;
                    case 5: SearchVehicles(); break;
                    case 6: ListVehicleTypes(); break;
                    case 0: running = false; break;
                    default: PrintError("Invalid option. Try again."); break;
                }
            }
        }

        /// <summary>
        /// Initierar garaget genom att be användaren om en kapacitet.
        /// Frågr om användaren vill fylla garaget med några exempelfordon.
        /// </summary>
        private void InitGarage()
        {
            int capacity = ReadInt("Enter garage capacity: ", 1, 1000);
            _garage = new Garage<Vehicle>(capacity);
            Console.WriteLine($"Garage created with capacity {capacity}.");

            Console.Write("Populate with sample vehicles? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLower() == "y")
                PopulateSample();
        }

        /// <summary>
        /// Skapar en array och fyller garaget med några exempelfordon.
        /// </summary>
        private void PopulateSample()
        {
            var samples = new Vehicle[]
            {
                new Car("ABC123", "Red", FuelType.Gasoline),
                new Car("XYZ789", "Blue", FuelType.Diesel),
                new Motorcycle("MC001", "Black", 600),
                new Airplane("AIR01", "White", 2),
                new Bus("BUS001", "Yellow", 50),
                new Boat("BOAT1", "Green", 8.5)
            };

            foreach (var v in samples)
            {
                if (_garage!.Count < _garage.Capacity)
                    _garage.Add(v);
            }
            Console.WriteLine($"{_garage!.Count} sample vehicle(s) added.");
        }

        /// <summary>
        /// Undermenyn som visar de olika alternativ som användaren kan välja mellan.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine($"--- Menu (Parked: {_garage!.Count}/{_garage.Capacity}) ---");
            Console.WriteLine("1. List all vehicles");
            Console.WriteLine("2. Add vehicle");
            Console.WriteLine("3. Remove vehicle");
            Console.WriteLine("4. Find vehicle by registration number");
            Console.WriteLine("5. Search vehicles by properties");
            Console.WriteLine("6. List vehicle types and count");
            Console.WriteLine("0. Exit");
        }

        /// <summary>
        /// Visar en lista över alla fordon i garaget, inklusive deras typ, registreringsnummer, färg, antal hjul och detaljer.
        /// </summary>
        private void ListVehicles()
        {
            if (_garage!.Count == 0) { Console.WriteLine("The garage is empty."); return; }
            foreach (var v in _garage)
                Console.WriteLine(v);
        }

        /// <summary>
        /// Listar varje fordonstyp och hur många av den typen som för närvarande är parkerade.
        /// </summary>
        private void ListVehicleTypes()
        {
            if (_garage!.Count == 0) { Console.WriteLine("The garage is empty."); return; }

            var counts = new Dictionary<string, int>();
            foreach (Vehicle v in _garage)
            {
                string typeName = v.GetType().Name;
                if (!counts.ContainsKey(typeName))
                    counts[typeName] = 0;
                counts[typeName]++;
            }

            Console.WriteLine();
            foreach (var entry in counts)
                Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        /// <summary>
        /// Om garaget är fullt visas ett felmeddelande.
        /// Annars ber programmet användaren om vilken typ av fordon som ska läggas till, dess registreringsnummer, färg och eventuella egenskaper.
        /// (t.ex. bränsle, cylindervolym osv.)
        /// </summary>
        private void AddVehicle()
        {
            if (_garage!.Count >= _garage.Capacity)
            {
                PrintError("Garage is full!");
                return;
            }

            Console.WriteLine("Vehicle types: 1=Car  2=Motorcycle  3=Airplane  4=Bus  5=Boat");
            int type = ReadInt("Choose type: ", 1, 5);

            Console.Write("Registration number: ");
            string reg = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (string.IsNullOrEmpty(reg)) { PrintError("Invalid registration."); return; }
            if (_garage.Contains(reg)) { PrintError("A vehicle with that registration already exists."); return; }

            Console.Write("Color: ");
            string color = Console.ReadLine()?.Trim() ?? "Unknown";

            Vehicle? vehicle = type switch
            {
                1 => CreateCar(reg, color),
                2 => CreateMotorcycle(reg, color),
                3 => CreateAirplane(reg, color),
                4 => CreateBus(reg, color),
                5 => CreateBoat(reg, color),
                _ => null
            };

            if (vehicle is null) return;

            if (_garage.Add(vehicle))
                Console.WriteLine($"Vehicle {reg} added.");
            else
                PrintError("Could not add vehicle.");
        }

        /// <summary>
        /// Metod för att skapa ett Car-, Motorcycle-, Airplane-, Bus- eller Boat-objekt.
        /// Med möjlighet att ange registreringsnummer, färg samt bränsle-/cylindervolym-/motor-/sittplats-/längd-egenskap.
        /// </summary>
        private Car CreateCar(string reg, string color)
        {
            Console.WriteLine("Fuel types: 0=Gasoline  1=Diesel  2=Electric  3=Hybrid");
            int ft = ReadInt("Choose fuel type: ", 0, 3);
            return new Car(reg, color, (FuelType)ft);
        }

        private Motorcycle CreateMotorcycle(string reg, string color)
        {
            double cc = ReadDouble("Cylinder volume (cc): ", 50, 3000);
            return new Motorcycle(reg, color, cc);
        }

        private Airplane CreateAirplane(string reg, string color)
        {
            int engines = ReadInt("Number of engines: ", 1, 8);
            return new Airplane(reg, color, engines);
        }

        private Bus CreateBus(string reg, string color)
        {
            int seats = ReadInt("Number of seats: ", 1, 200);
            return new Bus(reg, color, seats);
        }

        private Boat CreateBoat(string reg, string color)
        {
            double length = ReadDouble("Length in meters: ", 1, 500);
            return new Boat(reg, color, length);
        }

        /// <summary>
        /// Alternativ för att ta bort ett fordon baserat på registreringsnummer.
        /// Om fordonet inte hittas visas ett felmeddelande.
        /// </summary>
        private void RemoveVehicle()
        {
            Console.Write("Enter registration number to remove: ");
            string reg = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (_garage!.Remove(reg))
                Console.WriteLine($"Vehicle {reg} removed.");
            else
                PrintError("Vehicle not found.");
        }

        /// <summary>
/// Alternativ för att hitta ett fordon baserat på registreringsnummer.
/// Om fordonet inte hittas visas ett felmeddelande.
        /// </summary>
        private void FindVehicle()
        {
            Console.Write("Enter registration number: ");
            string reg = Console.ReadLine()?.Trim().ToUpper() ?? "";
            var v = _garage!.Find(reg);
            if (v is not null)
                Console.WriteLine(v);
            else
                PrintError("Vehicle not found.");
        }

        /// <summary>
        /// Alternativ för att söka efter fordon baserat på olika egenskaper.
        /// Om inga fordon matchar sökkriterierna visas ett felmeddelande.
        /// </summary>
        private void SearchVehicles()
        {
            Console.WriteLine("\n-- Search by Vehicle Properties --");
            Console.WriteLine("Leave a field blank to skip that filter.\n");

            /// Fordon typ filter
            Console.WriteLine("Vehicle type filter: 0=Any  1=Car  2=Motorcycle  3=Airplane  4=Bus  5=Boat");
            Console.Write("Choose type (default 0): ");
            string typeInput = Console.ReadLine()?.Trim() ?? "";
            int typeFilter = 0;
            if (!string.IsNullOrEmpty(typeInput))
                int.TryParse(typeInput, out typeFilter);

            /// Färg filter
            Console.Write("Color (leave blank to skip): ");
            string colorFilter = Console.ReadLine()?.Trim() ?? "";

            /// Hjul filter
            Console.Write("Number of wheels (leave blank to skip): ");
            string wheelsInput = Console.ReadLine()?.Trim() ?? "";
            int wheelsFilter = -1;
            if (!string.IsNullOrEmpty(wheelsInput))
                int.TryParse(wheelsInput, out wheelsFilter);

            /// Applicera filters
            Vehicle[] results = _garage!.FindAll(v =>
            {
                if (typeFilter != 0)
                {
                    bool typeMatch = typeFilter switch
                    {
                        1 => v is Car,
                        2 => v is Motorcycle,
                        3 => v is Airplane,
                        4 => v is Bus,
                        5 => v is Boat,
                        _ => true
                    };
                    if (!typeMatch) return false;
                }

                if (!string.IsNullOrEmpty(colorFilter) &&
                    !v.Color.Equals(colorFilter, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (wheelsFilter >= 0 && v.NumberOfWheels != wheelsFilter)
                    return false;

                return true;
            });

            if (results.Length == 0)
            {
                PrintError("No vehicles matched your search.");
                return;
            }

            Console.WriteLine($"\n{results.Length} vehicle(s) found:");
            foreach (var v in results)
                Console.WriteLine(v);
        }

        /// <summary>
        /// Hjälpmetod för att läsa ett heltal med validering och intervall kontroll.
        /// Annars kommer den att fortsätta fråga användaren tills ett giltigt nummer anges.
        /// Används för fordonstyp, sittplatser etc.
        /// </summary>
        private static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                PrintError($"Please enter a number between {min} and {max}.");
            }
        }

        /// <summary>
        /// Hjälpmetod för att läsa ett decimaltal med validering och intervall kontroll.
        /// Annars kommer den att fortsätta fråga användaren tills ett giltigt nummer anges.
        /// Används för cylinder volym och båt längd etc.
        /// </summary>
        private static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value >= min && value <= max)
                    return value;
                PrintError($"Please enter a number between {min} and {max}.");
            }
        }

        /// <summary>
        /// Läser huvudmenyvalet och kontrollerar ogiltig inmatning.
        /// Om inmatningen är ogiltig returneras -1.
        /// Vilket sedan hanteras i default-fallet i menyns switch och visar ett felmeddelande.
        /// </summary>
        private int ReadOption()
        {
            Console.Write("Choice: ");
            return int.TryParse(Console.ReadLine(), out int v) ? v : -1;
        }

        /// <summary>
        /// Skriver ut felmeddelande i rött och återställer sedan färgen.
        /// </summary>
        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
