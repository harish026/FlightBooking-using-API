using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

//#nullable disable

namespace FlightTicketReservation.Models
{
    public partial class dupflight
    {
        [Key]
        [DisplayName("Flight ID")]
        public int Flightid { get; set; }
        [Required(ErrorMessage ="enter the flight name")]
        [DisplayName("Flight Name")]
        public string Flightname { get; set; }
        [Required(ErrorMessage ="source should not be empty")]
        public string Source { get; set; }
        [Required(ErrorMessage ="destination should not be empty")]
        public string Destination { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Departuretime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Arrivaltime { get; set; }
        [Required(ErrorMessage ="enter the total capacity of the flight")]
        [DisplayName("seat count")]
        [Range(20,200,ErrorMessage ="capacity should be in range of 20 to 200")]
        public int? Totalcapacity { get; set; }
        [Required(ErrorMessage ="enter the cost per seat")]
        public double? Costperseat { get; set; }
        
        public IFormFile Imagepath { get; set; }
    }
}
