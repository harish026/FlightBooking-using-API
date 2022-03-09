using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flightapi.Repo;
using Flightapi.Models;
using Flightapi.Service;

namespace Flightapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightser<Flight> pr;
        public FlightController(IFlightser<Flight> service)
        {
            pr = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return pr.GetFlights();
        }

        // GET api/<ProductController>/id
        [HttpGet("{id}")]
        public Flight Get(int id)
        {
            return pr.GetFlightById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Flight p)
        {
            pr.AddFlight(p);
        }

        // PUT api/<ProductController>/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Flight p)
        {
            pr.DeleteFlight(p.Fid);
            pr.AddFlight(p);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pr.DeleteFlight(id);
        }
    }
}
