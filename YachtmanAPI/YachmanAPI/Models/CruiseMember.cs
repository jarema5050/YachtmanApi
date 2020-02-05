using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YachmanAPI.Models
{
    public class CruiseMember
    {   
        public int Id { get; set; }
        [ForeignKey("Cruise")]
        public int? CruiseId { get; set; }
        public Cruise Cruise{ get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public AppUser User { get; set; }
    }
}