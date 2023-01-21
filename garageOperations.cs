using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CRUD
{
    internal class garageOperations
    {
        CarsGarage garage;

        public garageOperations()
        {
            this.garage = new CarsGarage();
        }

        public void databaseInitialization()
        {
            Crud.Create("database.txt", garage);
        }
        public void databaseRemove()
        {
            Crud.Delete("database.txt");
        }

        public void addCar(string producer)
        {
            Console.WriteLine("\nPodaj model samochodu (jeśli nie wiesz zostaw puste):");
            String model = Console.ReadLine();

            Console.WriteLine("\nPodaj kolor samochodu (jeśli nie wiesz zostaw puste):");
            String color = Console.ReadLine();

            Console.WriteLine("\nPodaj rodzaj paliwa (jeśli nie wiesz zostaw puste):");
            String fuel = Console.ReadLine();

            Console.WriteLine("\nPodaj rok produkcji:");
            int yearOfProduction = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPodaj numer rejestracyjny (jeśli nie wiesz zostaw puste):");
            String plateNumber = Console.ReadLine();

            Console.WriteLine("\nPodaj przebieg [w tyś. km]:");
            double milleage = double.Parse(Console.ReadLine());

            Console.WriteLine("\nPodaj czy (jeśli nie wiesz domyślnie manual):\n1.Manual\n2.Automat");
            int choice = int.Parse(Console.ReadLine());
            bool isAutomatic;
            switch (choice) {
                case 1: isAutomatic = false; break;
                case 2: isAutomatic = true; break;
                default: isAutomatic = false;  Console.WriteLine("Nie wybrałeś podanej opcji. Zakładam, że manual."); break;
            }


            Car car = new Car(producer)
            {
                prodcer = producer,
                model = model,
                color = color,
                fuel = fuel,
                yearOfProduction = yearOfProduction,
                plateNumber = plateNumber,
                milleage = milleage,
                isAutomatic = isAutomatic
            };

            garage = Crud.Read<CarsGarage>("database.txt");
            garage.myGarage.Add(car);
            Crud.Write<CarsGarage>("database.txt", garage);

            Console.WriteLine("\nDane o samochodzie zostały zapisane w bazie danych.\n");

        }

        public void showCars(int index = -1)
        {
            garage = Crud.Read<CarsGarage>("database.txt");

            if (index == -1)
            {
                foreach (Car x in garage.myGarage)
                {
                    Console.WriteLine("| id:{0} | producer:{1} | model:{2} | color:{3} | fuel:{4} | yearOfProduction:{5} | plateNumber:{6} | milleage:{7} | isAutomatic:{8} |", garage.myGarage.IndexOf(x), x.prodcer, x.model, x.color, x.fuel, x.yearOfProduction, x.plateNumber, x.milleage, x.isAutomatic);
                }
                Console.WriteLine();
            }
            else if(index >= 0 && index < garage.myGarage.Count)
            {
                Car x = garage.myGarage[index];
                Console.WriteLine("| id:{0} | producer:{1} | model:{2} | color:{3} | fuel:{4} | yearOfProduction:{5} | plateNumber:{6} | milleage:{7} | isAutomatic:{8} |", garage.myGarage.IndexOf(x), x.prodcer, x.model, x.color, x.fuel, x.yearOfProduction,x.plateNumber, x.milleage, x.isAutomatic);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nie ma w bazie auta o podanym id.\n");
            }
        }

        public void editCar(int index)
        {
            garage = Crud.Read<CarsGarage>("database.txt");

            Console.WriteLine("\n1.Wybierz parametr do zmiany:");
            Console.WriteLine("1.producer\n2.model\n3.color\n4.fuel\n5.yearOfProduction\n6.plateNumber\n7.milleage\n8.isAutomatic\n");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Console.WriteLine("\nproducer:"); garage.myGarage[index].prodcer = Console.ReadLine(); break;
                case 2: Console.WriteLine("\nmodel:"); garage.myGarage[index].model = Console.ReadLine(); break;
                case 3: Console.WriteLine("\ncolor:"); garage.myGarage[index].color = Console.ReadLine(); break;
                case 4: Console.WriteLine("\nfuel"); garage.myGarage[index].fuel = Console.ReadLine(); break;
                case 5: Console.WriteLine("yearOfProduction"); garage.myGarage[index].yearOfProduction = int.Parse(Console.ReadLine()); break;
                case 6: Console.WriteLine("\nplateNumber:"); garage.myGarage[index].plateNumber = Console.ReadLine(); break;
                case 7: Console.WriteLine("\nmilleage:"); garage.myGarage[index].milleage = double.Parse(Console.ReadLine()); break;
                case 8: Console.WriteLine("\nisAutomatic [false/true]:"); garage.myGarage[index].isAutomatic = bool.Parse(Console.ReadLine()); break;
                default: Console.WriteLine("Nie wybrano żadnej z podanych opcji.\n"); break;
            }

            Crud.Write<CarsGarage>("database.txt", garage);

            Console.WriteLine("\nWskazane zmiany zostały wprowadzone.\n");
        }

        public void deleteCar(int index = -1)
        {
            garage = Crud.Read<CarsGarage>("database.txt");

            if (index == -1)
            {
                garage.myGarage.Clear();
                Crud.Write<CarsGarage>("database.txt", garage);
                Console.WriteLine("Z bazy usunięto wszystkie samochody.\n");
            }
            else if (index >= 0 && index < garage.myGarage.Count)
            {
                Car x = garage.myGarage[index];
                garage.myGarage.Remove(x);
                Crud.Write<CarsGarage>("database.txt", garage);
                Console.WriteLine("Samochód o podanym id został usunięty. UWAGA!!! id samochodów z większym numerem niż auto usunięte uległy przesunięciu o -1!\n");
                
            }
            else
            {
                Console.WriteLine("Nie ma w bazie auta o podanym id.\n");
            }
        }
    }
}
