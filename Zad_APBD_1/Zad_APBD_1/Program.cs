namespace Zad_APBD_1;

class Program
    { 
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            
            Ship ship = new Ship("Oceanic", 2000, 5);
            dataManager.AddShip(ship);
            Console.WriteLine($"Dodano statek: {ship}");
            
            Container gasContainer = new GasContainer(500, 10, 5, 50, 2.5, dataManager.FindCargo("Azot"));
            Container liquidContainer = new LiquidContainer(800, 15, 6, 70, dataManager.FindCargo("Paliwo"));
            Container refrigeratedContainer = new RefrigeratedContainer(600, 12, 5, 40, -5, dataManager.FindCargo("Mięso"));

            dataManager.AddContainer(gasContainer);
            dataManager.AddContainer(liquidContainer);
            dataManager.AddContainer(refrigeratedContainer);

            Console.WriteLine("Dodano kontenery:");
            Console.WriteLine(gasContainer);
            Console.WriteLine(liquidContainer);
            Console.WriteLine(refrigeratedContainer);
            
            try
            {
                gasContainer.Load(200);
                liquidContainer.Load(300);
                refrigeratedContainer.Load(150);
                
                Console.WriteLine("Kontenery po załadunku:");
                Console.WriteLine(gasContainer);
                Console.WriteLine(liquidContainer);
                Console.WriteLine(refrigeratedContainer);
                
                gasContainer.Unload(50);
                refrigeratedContainer.Unload(100);
                
                Console.WriteLine("Kontenery po rozładunku:");
                Console.WriteLine(gasContainer);
                Console.WriteLine(refrigeratedContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd operacji: {ex.Message}");
            }
            
            try
            {
                ship.AddContainer(gasContainer);
                ship.AddContainer(liquidContainer);
                Console.WriteLine("Kontenery dodane do statku:");
                Console.WriteLine(ship);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie można dodać kontenera: {ex.Message}");
            }
            
            Console.WriteLine("Lista wszystkich statków:");
            dataManager.PrintAllShips();

            Console.WriteLine("Lista wszystkich kontenerów:");
            dataManager.PrintAllContainers();

            Console.WriteLine("Lista dostępnych ładunków:");
            dataManager.PrintAllCargo();
        }
    }