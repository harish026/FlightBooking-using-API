using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FlightTicketReservation.Models{
    public class admin{
        [Key]
        public int id{get;set;}
        [Required(ErrorMessage ="enter the admin name")]
        public string name{get;set;}
        [Required(ErrorMessage ="enter the admin password")]
        public string password{get;set;}
    }
}