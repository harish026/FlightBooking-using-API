using Customerapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerapi.Repo{
    public class CustomerRepo : ICustomerRepo
    {
        Customer c=new Customer();
        public void AddCustomer(Customer c1)
        {
            c.AddCustomer(c1);
        }

        public Customer GetCustomerById(int id)
        {
            return c.GetCustomerByID(id);
        }

        public List<Customer> GetCustomers()
        {
            return c.GetCustomers();
        }
    }
}