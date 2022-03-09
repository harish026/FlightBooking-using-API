using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flightbookingapi.Models
{
    public class Flight
    {
        [Key]
        public int Fid { get; set; }
        [Required(ErrorMessage ="enter the Flight Name")]
        public string Fname { get; set; }
        [Required(ErrorMessage ="source cannot be empty")]
        public string Source { get; set; }
        [Required(ErrorMessage ="destination cannot be empty")]
        public string Dest { get; set; }
        [Required(ErrorMessage ="enter the departure time")]
        public DateTime? Dtime { get; set; }
        [Required(ErrorMessage ="enter the Arrival Time")]
        public DateTime? Atime { get; set; }
        [Required(ErrorMessage ="enter the number of seats")]
        public int Seat { get; set; }
        [Required(ErrorMessage ="enter the price per ticket")]
        public int Price { get; set; }
    }
}
