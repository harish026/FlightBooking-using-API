using System;
using System.Collections.Generic;
using System.Linq;

namespace Customerapi.Models
{
    public partial class Customer
    {
        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Password { get; set; }
        public static List<Customer> cs=new List<Customer>();
        public Customer(){

        }
        public Customer(int cid,string cname,string pass){
            Customerid=cid;
            Customername=cname;
            Password=pass;
        }
        public List<Customer> GetCustomers(){
            return cs;
        }
        public Customer GetCustomerByID(int id){
            Customer c1=cs.Where(x=>x.Customerid==id).FirstOrDefault();
            return c1;
        }
        public void AddCustomer(Customer c1){
            cs.Add(c1);
        }
        
    }
}
