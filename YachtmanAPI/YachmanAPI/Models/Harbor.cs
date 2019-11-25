using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YachmanAPI.Models
{
    public class Harbor
    {
        
        public int Id { get; set; }
        [StringLength(200)]
        public string City { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        [StringLength(80)]
        public string Country { get; set; }
    }
}