using Flightapi.Models;
using Flightapi.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flightapi.Service
{
    public class FlightSer : IFlightser<Flight>
    {
        private readonly IFlightrp<Flight> p;
        public FlightSer()
        {

        }
        public FlightSer(IFlightrp<Flight> _p)
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
