using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class Calculate
    {
        public static void Manage(taxówy center)
        {
            Console.WriteLine("PODAJ NUMER DZIELNICY DO KTÓREJ CHCESZ WEZWAĆ TAKSÓWKĘ:");
            int selecteddistrict = Convert.ToInt32(Console.ReadLine());
            int distanceselecteddistrict = center.Districts[selecteddistrict - 1].DistanceFromCentrum;
            foreach (złotówa cab in center.Cabs)
            {
                int time = distanceselecteddistrict - center.Cabs[cab.Id - 1].CurrentDistrict.DistanceFromCentrum;
                int absolutetime = Math.Abs(time);
                center.Cabs[cab.Id - 1].TravelTime = absolutetime;
                if (center.Cabs[cab.Id - 1].TravelTime == 0)
                {
                    center.Cabs[cab.Id - 1].TravelTime = 4;
                    if (center.Cabs[cab.Id - 1].IsAvailable == false)
                    {
                        center.Cabs[cab.Id - 1].TravelTime += 12;
                    }
                }
                else if (center.Cabs[cab.Id - 1].TravelTime != 0)
                {
                    center.Cabs[cab.Id - 1].TravelTime *= 5;
                    if (center.Cabs[cab.Id - 1].IsAvailable == false)
                    {
                        center.Cabs[cab.Id - 1].TravelTime += 12;
                    }
                }
            }

            int mintime = 9999;
            foreach (złotówa cab in center.Cabs)
            {
                if (center.Cabs[cab.Id - 1].TravelTime < mintime)
                {
                    mintime = center.Cabs[cab.Id - 1].TravelTime;
                }
            }

            foreach (złotówa cab in center.Cabs)
            {
                if (mintime == center.Cabs[cab.Id - 1].TravelTime)
                {
                    center.Cabs[cab.Id - 1].IsAvailable = false;
                    center.Cabs[cab.Id - 1].CurrentDistrict = center.Districts[selecteddistrict - 1];
                    mintime += 9999;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ZLECENIE REALIZUJE: {center.Cabs[cab.Id - 1].Car}");
                    Console.WriteLine($"CZAS DOJAZDU: {center.Cabs[cab.Id - 1].TravelTime} min.");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            RecalculateNumberOfCabs(center);
            Console.WriteLine("LISTA DZIELNIC");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("NUMER | NAZWA | ILOŚĆ TAKSÓWEK");
            foreach (odległość district in center.Districts)
                Console.WriteLine($"{center.Districts[district.Number - 1].Number} | {center.Districts[district.Number - 1].Name} | {center.Districts[district.Number - 1].NumberOfCabs} ");
            Console.WriteLine("");
            Console.WriteLine("LISTA TAKSÓWEK");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("SAMOCHÓD | STATUS | AKTUALNA LOKALIZACJA | Czas Dojazdu");
            foreach (złotówa cab in center.Cabs)
                Console.WriteLine($"{center.Cabs[cab.Id - 1].Car} | {center.Cabs[cab.Id - 1].Status} | {center.Cabs[cab.Id - 1].CurrentDistrict.Name} | ({center.Cabs[cab.Id - 1].TravelTime} min.)");
            Console.WriteLine("");
        }

        private static void RecalculateNumberOfCabs(taxówy center)
        {
            foreach (odległość district in center.Districts)
            {
                district.NumberOfCabs = 0;
            }

            foreach (złotówa cab in center.Cabs)
            {
                var indexOfDistrict = center.Districts.IndexOf(cab.CurrentDistrict);
                center.Districts[indexOfDistrict].NumberOfCabs += 1;
            }
        }
    }
}
