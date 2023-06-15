using System;

namespace Taxi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            taxówy center = new taxówy();
            bool finished = false;
            do
            {
                MAIN.Menu();
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.Clear();
                        MAIN.ShowDistrict(center);
                        MAIN.ShowCabs(center);
                        break;
                    case 2:
                        Console.Clear();
                        Calculate.Manage(center);
                        break;
                    case 3:
                        Console.Clear();
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("@@@@@@@@@@@@@ZŁY GUZIK@@@@@@@@@@@@@@@@");
                        Console.WriteLine("");
                        break;
                }
            } while (!finished);
        }
    }
}