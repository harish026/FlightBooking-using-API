using System;
using System.Collections.Generic;

#nullable disable

namespace FlightTicketReservation.Models
{
    public partial class RouteDetail
    {
        public int Routeid { get; set; }
        public int? Flightid { get; set; }
        public string Routedesc { get; set; }
    }
}
