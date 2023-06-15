using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public static class MAIN
    {
        public static void Menu()
        {
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA WSZYSTKICH DZIELNIC I TAKSÓWEK");
            Console.WriteLine("2 => ZAMÓW TAKSÓWKĘ");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");
        }
        public static void ShowDistrict(taxówy show)
        {
            Console.WriteLine("LISTA DZIELNIC");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("NUMER | NAZWA | ILOŚĆ TAKSÓWEK");
            foreach (odległość district in show.Districts)
                Console.WriteLine($"{show.Districts[district.Number - 1].Number} | {show.Districts[district.Number - 1].Name} | {show.Districts[district.Number - 1].NumberOfCabs} ");
        }
        public static void ShowCabs(taxówy show)
        {
            Console.WriteLine("");
            Console.WriteLine("LISTA TAKSÓWEK");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("SAMOCHÓD | STATUS | AKTUALNA LOKALIZACJA");
            foreach (złotówa cab in show.Cabs)
                Console.WriteLine($"{show.Cabs[cab.Id - 1].Car} | {show.Cabs[cab.Id - 1].Status} | {show.Cabs[cab.Id - 1].CurrentDistrict.Name}");
            Console.WriteLine("");
        }
    }
}
