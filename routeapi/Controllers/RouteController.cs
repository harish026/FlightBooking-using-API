using routeapi.Models;
using routeapi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace routeapi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase{
        RouteRepo rr=new RouteRepo();

        [HttpGet]
        public IEnumerable<Route> Get()
        {
            return rr.GetRoutes();
        }

        [HttpGet("{id}")]
        public Route Get(int id)
        {
            return rr.GetRouteById(id);
        }
        [HttpPost]
        public  void Post([FromBody] Route r)
        {
            rr.AddRoute(r);
            
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Route r)
        {
            rr.DeleteRoute(id);
            rr.AddRoute(r);
        }
         [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rr.DeleteRoute(id);
        }
    }
}