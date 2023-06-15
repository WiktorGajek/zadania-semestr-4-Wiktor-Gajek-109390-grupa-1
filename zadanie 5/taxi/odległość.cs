using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class odległość
    {
        public odległość(int number, string name, int distance)
        {
            Number = number;
            Name = name;
            DistanceFromCentrum = distance;
            NumberOfCabs = 1;
        }
        public int Number { get; }
        public string Name { get; }
        public int DistanceFromCentrum { get; }
        public int NumberOfCabs { get; set; }
    }
}
