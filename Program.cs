
namespace CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            garageOperations newGarage = new garageOperations();
            newGarage.databaseInitialization();
            bool isWorking = true;

            Console.WriteLine("Witaj w programie obsługi bazy danych!");
            while (isWorking)
            {
                int choice;

                Console.WriteLine("Dokonaj wyboru pocji poniżej:\n");
                Console.WriteLine("1.Dodaj nowe auto do bazy\n2.Wyświetl dane wszystkich samochodów\n3.Wyświetl dane samochodu o podanym numerze\n4.Zmień dane wybraego samochodu\n5.Usuń samochód o wybranym numerze\n6.Usuń wszystkie samochody\n7.Skasuj baze danych.(Automatycznie zamknie program po usunięciu)\n8.Wyjdz z programu.\n");
                
                bool checkChoice = int.TryParse(Console.ReadLine(), out choice);

                if(checkChoice)
                {
                    switch (choice)
                    {
                        case 1: Console.WriteLine("Podaj markę samochodu:"); newGarage.addCar(Console.ReadLine()); break;
                        case 2: Console.WriteLine("\nW bazie danych znaleziono następujące samochody:"); newGarage.showCars(); break;
                        case 3: Console.WriteLine("\nPodaj id pojazdu, którego dane chcesz uzyskać:"); newGarage.showCars(int.Parse(Console.ReadLine())); break;
                        case 4: Console.WriteLine("\nPodaj id pojazdu, którego dane chcesz edytować:"); newGarage.editCar(int.Parse(Console.ReadLine())); break;
                        case 5: Console.WriteLine("\nPodaj id pojazdu, którego dane chcesz usunąć:"); newGarage.deleteCar(int.Parse(Console.ReadLine())); break;
                        case 6: Console.WriteLine("\nZ bazy zostały usunięte wszystkie pojazdy."); newGarage.deleteCar(); break;
                        case 7: Console.WriteLine("Usuń baze danych."); newGarage.databaseRemove(); isWorking = false; break;
                        case 8: Console.WriteLine("Do widzenia!"); isWorking = false; break;
                        default: Console.WriteLine("Podana liczba nie odpowiada żadnej opcji. Spróbuj ponownie.\n"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Podany tekst nie jest liczbą. Spróbuj ponownie.\n");
                }
            }
        }
    }
}