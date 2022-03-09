using Bookapi.Models;
using Bookapi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        Bookrp br = new Bookrp();
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return br.GetBookings();
        }

        // GET api/<BookController>/id
        [HttpGet("{id}")]
        public IEnumerable<Book> Get(int id)
        {
            return br.GetBookById(id);
        }
        [HttpGet("bid/{id}")]
        public Book GetById(int id){
            return br.GetById(id);
        }
        [HttpPost]
        public  void Post([FromBody] Book b)
        {
            br.AddBooking(b);
            
        }
        string Baseurl = "https://localhost:5001/";

        [HttpGet("Flights")]
        public async Task<List<Flight>> GetFlights()
        {

            
            List<Flight> FltInfo = new List<Flight>();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Flight");
                if (Res.IsSuccessStatusCode)
                {
                    var FlightResponse = Res.Content.ReadAsStringAsync().Result;
                    FltInfo = JsonConvert.DeserializeObject<List<Flight>>(FlightResponse);
                    return FltInfo;
                }
                else
                {
                    return null;
                }

            }
        }
        [HttpGet("Flights/{id}")]
        public async Task<Flight> GetFlightById(int id){
            Flight f1=new Flight();
            using (var httpClient =new HttpClient()){
                httpClient.BaseAddress = new Uri(Baseurl);
                using(var response=await httpClient.GetAsync("api/Flight/"+id)){
                    string apiResponse=await response.Content.ReadAsStringAsync();
                    f1=JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return f1;

        }
    
            
        

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book b)
        {
            br.CancelBooking(id);
            br.AddBooking(b);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            br.CancelBooking(id);
        }
    }
}
