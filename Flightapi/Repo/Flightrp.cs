using Flightapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flightapi.Repo
{
    public class Flightrp:IFlightrp<Flight>
    {
        private readonly IFlight<Flight> p;
        public Flightrp()
        {

        }
        public Flightrp(IFlight<Flight> _p)
        {
            p = _p;
        }
        public void AddFlight(Flight p)
        {
            p.AddFlight(p);   
        }

        public void DeleteFlight(int id)
        {
            p.DeleteFlight(id);
        }

        public Flight GetFlightById(int id)
        {
            return p.GetFlightById(id);
        }

        public List<Flight> GetFlights()
        {
           return p.GetFlights();
        }
    }
}
