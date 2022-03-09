using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flightbookingapi.Models
{
    public class Book
    {
        [DisplayName("Booking Id")]
        public int Bid { get; set; }
        [DisplayName("Flight Id")]
        public int Fid { get; set; }
        [DisplayName("Customer Id")]
        public int Cid { get; set; }
        [Required(ErrorMessage ="enter the number of passangers")]
        [DisplayName("Number of Passangers")]
        public int Nop { get; set; }
        public float Amount { get; set; }
    }
}