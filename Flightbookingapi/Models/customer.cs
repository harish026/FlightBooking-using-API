using System;
using System.Collections.Generic;

#nullable disable

namespace Flightbookingapi.Models
{
    public partial class customer
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Password { get; set; }
    }
}
