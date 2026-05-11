# C# Övning 3 - Garage 1.0

| Filer | Ansvar |
| :--- | :--- |
| **Vehicle.cs** | Fordonsklass – `RegistrationNumber`, `Color`, `NumberOfWheels` |
| **Car.cs** | Subklass – adderar `FuelType` (Gasoline/Diesel/Electric/Hybrid) |
| **Motorcycle.cs** | Subklass – adderar `CylinderVolume`|
| **Airplane.cs** | Subklass – adderar `NumberOfEngines` |
| **Bus.cs** | Subklass – adderar `NumberOfSeats` |
| **Boat.cs** | Subklass – adderar `Length` |
| **Garage.cs** | Kollektion av fordon |
| **GarageUI.cs** | Meny - användargränssnitt |
| **Program.cs** | Ingångsport – kör `GarageUI` |

## Funktioner

#### Meny:
- `ListVehicles()` - Lista över alla fordon
- `AddVehicle()` - Lägga till ett fordon
- `RemoveVehicle()` - Ta bort fordon
- `FindVehicle()` - Hitta fordon utifrån registreringsnummer
- `SearchVehicles()` - Hitta fordon utifrån egenskaper;
-  `ListVehicleTypes()` - Listar varje fordonstyp och hur många av den typen som är parkerade
- Funktion att lägga till exempel fordon
- Sätta en kapacitet (antal parkeringsplatser) vid instansieringen av ett nytt garage
- Användaren får feedback på att saker gått bra eller dåligt
