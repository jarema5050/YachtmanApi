using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YachmanAPI.Models
{
    public class Cruise
    {
        public Harbor DepartureHarbor { get; set; }
        public Harbor DepartureHarborId { get; set; }
        public Harbor ArrivalHarbor { get; set; }
        public Harbor ArrivalHarborId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}