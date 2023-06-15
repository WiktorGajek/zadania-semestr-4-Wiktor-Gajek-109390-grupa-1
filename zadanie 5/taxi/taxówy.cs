using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class taxówy
    {
        public taxówy()
        {
            CreateDistricts();
            CreateCabs();
        }

        public List<odległość> Districts { get; set; } = new List<odległość>();
        public List<złotówa> Cabs { get; set; } = new List<złotówa>();

        private void CreateDistricts()
        {
            Districts.Add(new odległość(1, "Retkinia", -2));
            Districts.Add(new odległość(2, "Łódź Kaliska", -1));
            Districts.Add(new odległość(3, "Śródmieście", 0));
            Districts.Add(new odległość(4, "Widzew", 1));
            Districts.Add(new odległość(5, "Janów", 3));
        }
        private void CreateCabs()
        {
            Cabs.Add(new złotówa(1, "Ty to jest Civic?", Districts[0]));
            Cabs.Add(new złotówa(2, "Fiat Multipla", Districts[1]));
            Cabs.Add(new złotówa(3, "Mercedes A Klasa", Districts[2]));
            Cabs.Add(new złotówa(4, "Skodunia", Districts[3]));
            Cabs.Add(new złotówa(5, "Volkswagen Passat Król Polskich Dróg", Districts[4]));
        }
    }
}
