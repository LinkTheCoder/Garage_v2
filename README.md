# C# Övning - Garage v2

| Filer | Ansvar |
| :--- | :--- |
| **IVehicle.cs** | Interface för fordon – `RegistrationNumber`, `Color`, `NumberOfWheels` |
| **IHandler.cs** | Interface för garage-logik – definierar operationer som UI använder |
| **IUI.cs** | Interface för användargränssnittet |
| **Vehicle.cs** | Fordonsklass – implementerar `IVehicle` |
| **Car.cs** | Subklass – adderar `FuelType` (Gasoline/Diesel/Electric/Hybrid) |
| **Motorcycle.cs** | Subklass – adderar `CylinderVolume` |
| **Airplane.cs** | Subklass – adderar `NumberOfEngines` |
| **Bus.cs** | Subklass – adderar `NumberOfSeats` |
| **Boat.cs** | Subklass – adderar `Length` |
| **Garage.cs** | Generisk kollektion `Garage<T> where T : IVehicle` |
| **GarageHandler.cs** | Implementerar `IHandler` – hanterar logiken mellan UI och Garage |
| **GarageUI.cs** | Implementerar `IUI` – meny och all interaktion med användaren |
| **Program.cs** | Ingångsport – skapar `GarageHandler` och `GarageUI`, kör via interfaces |

## Funktioner

#### Meny:
- `ListVehicles()` – Lista över alla fordon
- `AddVehicle()` – Lägga till ett fordon
- `RemoveVehicle()` – Ta bort fordon
- `FindVehicle()` – Hitta fordon utifrån registreringsnummer
- `SearchVehicles()` – Hitta fordon utifrån egenskaper (typ, färg, antal hjul)
- `ListVehicleTypes()` – Listar varje fordonstyp och hur många av den typen som är parkerade
- Funktion att lägga till exempelfordon vid uppstart
- Sätta en kapacitet (antal parkeringsplatser) vid instansieringen av ett nytt garage
- Användaren får feedback på att saker gått bra eller dåligt
