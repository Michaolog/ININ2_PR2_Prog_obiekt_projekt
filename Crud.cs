using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace CRUD
{
    internal class Crud
    {
        public static void Write<T>(string fileName, T data)
        {
            var fs = new FileStream(fileName, FileMode.Open);
            var bf = new BinaryFormatter();

            bf.Serialize(fs, data);
            fs.Close();
        }

        public static T Read<T>(string fileName)
        {
            T obj = default(T);

            if (File.Exists(fileName))
            {
                var fs = new FileStream(fileName, FileMode.Open);
                var bf = new BinaryFormatter();

                obj = (T)bf.Deserialize(fs);
                fs.Close();
            }

            return obj;
        }

        public static void Delete(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine("Baza danych została usunięcia.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono bazy do usunięcia.");
            }
        }

        public static void Create<T>(string fileName, T data)
        {
            if (File.Exists(fileName) == false)
            {
                var fs = new FileStream(fileName, FileMode.Create);
                var bf = new BinaryFormatter();

                bf.Serialize(fs, data);
                fs.Close();
            }
        }
    }
}
