using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1._3
{
    internal class PlaneEngine
    {
        public string Name { get; set; }   
        public double Power { get; set; }

        public PlaneEngine() { }

        public PlaneEngine(string name, double power)
        {
            Name = name;
            Power = power;
        }
    }
}
