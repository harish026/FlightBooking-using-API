using Customerapi.Models;
using Customerapi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Customerapi.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase{
        CustomerRepo cr=new CustomerRepo();
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cr.GetCustomers();
        }

        // GET api/<BookController>/id
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return cr.GetCustomerById(id);
        }

        [HttpGet("Customer")]
        
            [HttpPost]
        public  void Post([FromBody] Customer c)
        {
                cr.AddCustomer(c);
            
        }

    }
    
}