using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Models
{
    public class Flight
    {
            public int Fid { get; set; }
            public string Fname { get; set; }
            public string Source { get; set; }
            public string Dest { get; set; }
            public DateTime? Dtime { get; set; }
            public DateTime? Atime { get; set; }
            public int Seat { get; set; }
            public int Price { get; set; }
    }
}
