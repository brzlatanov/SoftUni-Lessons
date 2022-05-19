using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RawData
{
    public class Car
    {

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            
        }

        public class Engine
        {
            public int Speed { get; set; }
            public int Power { get; set; }
        }

        public class Cargo
        {
            public string Type { get; set; }
            public  int Weight { get; set; }
        }

        public class Tire
        { 
            public int Age { get; set; }
            public double Pressure { get; set; }

        }
        public string Model { get; set; }
        
        public Engine CarEngine { get; set; }

        public Cargo CarCargo { get; set; }

        public Tire[] CarTires { get; set; }

    }
}
