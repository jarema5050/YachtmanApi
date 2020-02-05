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
        public DateDto DepartureDateDto { get; set; }
        public DateDto ArrivalDateDto { get; set; }
        public string ShipName { get; set; }
        public int OwnerId { get; set; }
    }
    public class DateDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}