using Customerapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customerapi.Repo{
    interface ICustomerRepo{
        public void AddCustomer(Customer c1);
        public List<Customer> GetCustomers();
        public Customer GetCustomerById(int id);
    }
}