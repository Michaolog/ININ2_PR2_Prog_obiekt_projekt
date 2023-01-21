using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    [Serializable]
    internal class Car
    {
        public String prodcer;
        public String model { get; set; }
        public String color { get; set;}
        public String fuel { get; set; }
        public int yearOfProduction { get; set; }
        public String plateNumber { get; set; }
        public double milleage { get; set; }
        public Boolean isAutomatic { get; set; }

        public Car(String producer)
        {
            this.prodcer = producer;
        }
    }
}
