using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    [Serializable]
    internal class CarsGarage
    {
       public List<Car> myGarage = new List<Car>();
       public List<int> init = new List<int>();
    }
}
