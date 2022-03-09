using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flightapi.Models;

namespace Flightapi.Repo
{
    public interface IFlightrp<Flight>
    {
        public void AddFlight(Flight p);
        public void DeleteFlight(int id);
        public List<Flight> GetFlights();
        public Flight GetFlightById(int id);

    }  
}
