using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flightapi.Models
{
   public interface IFlight<Flight>
    {
        public void AddFlight(Flight f);
        public void DeleteFlight(int id);
        public List<Flight>GetFlights();
        public Flight GetFlightById(int id);
    }
}
