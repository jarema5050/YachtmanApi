using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YachmanAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set;}
        [StringLength(60)]
        public string Surname { get; set; }
        [Required]
        public Experience Experience { get; set;}
        [Required]
        public string Country { get; set; } 
    }
    public enum Experience
    {
        Novice = 1,
        Intermediate = 2,
        Advanced = 3,
        Expert = 4
    }
}