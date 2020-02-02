using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YachmanAPI.Models
{
    public class Ship
    {
        public int Id { get; set; }
        [Required]
        [StringLength(140)]
        public string Name { get; set; }
        [Required]
        public AppUser Owner { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}