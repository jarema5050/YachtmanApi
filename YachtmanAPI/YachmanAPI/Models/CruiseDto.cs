using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YachmanAPI.Dtos
{
    public class CruiseDto
    {
        public int Id { get; set; }
        public string DepartureHarborName { get; set; }
        public string ArrivalHarborName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ShipName { get; set; }
    }
}