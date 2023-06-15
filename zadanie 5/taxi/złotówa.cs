using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public class złotówa
    {
        public złotówa(int id, string car, odległość district)
        {
            Id = id;
            Car = car;
            CurrentDistrict = district;
            IsAvailable = true;
        }
        public int Id { get; }
        public string Car { get; }
        public bool IsAvailable { get; set; }
        public odległość CurrentDistrict { get; set; }
        public int TravelTime { get; set; }
        public string Status => IsAvailable ? "wolny" : "zajęty";
    }
}
