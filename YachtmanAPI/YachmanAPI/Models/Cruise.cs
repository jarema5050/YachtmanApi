﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YachmanAPI.Models
{
    public class Cruise
    {
        public int Id { get; set; }

        [ForeignKey("DepartureHarbor")]
        public int? DepartureHarborId { get; set; }
        public Harbor DepartureHarbor { get; set; }
        [ForeignKey("ArrivalHarbor")]
        public int? ArrivalHarborId { get; set; }
        public Harbor ArrivalHarbor { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Ship Ship { get; set; }
        public int ShipId { get; set; }
    }
}