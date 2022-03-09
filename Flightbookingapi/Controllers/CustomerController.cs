using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Flightbookingapi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace Flightbookingapi.Controllers{
    public class CustomerController : Controller{
         public IActionResult login(){
            ViewBag.reg=HttpContext.Session.GetString("reg");
            return View();
        }
        public void check(customer c1,customer cs){
            if(c1!=null && c1.Customerid==cs.Customerid && c1.Password==cs.Password){
                HttpContext.Session.SetInt32("cid",c1.Customerid);
                HttpContext.Session.SetString("cname",c1.Customername);
                return;
            }
            else{
                //ViewBag.cloginerr="invalid username or password";
                throw new AccountNotFound("invalid Credentials :/");
            }
        }
        [HttpPost]
        public async Task<IActionResult> login(customer cs){
            customer c1=new customer();
            int id=cs.Customerid;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5011/api/Customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c1 = JsonConvert.DeserializeObject<customer>(apiResponse);
                }
            }
            try{
                check(c1,cs);
            }
            catch(Exception e){
                ViewBag.cloginerr=e.Message;
                return View();
            }
            return RedirectToAction("home");
            
        }
         public IActionResult home(){
            ViewBag.cname=HttpContext.Session.GetString("cname");
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            return View();
        }
         public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(customer c1){
            customer cobj=new customer();
            using(var hcl=new HttpClient()){
                hcl.BaseAddress=new Uri(baseurl3);
                StringContent content = new StringContent(JsonConvert.SerializeObject(c1), Encoding.UTF8, "application/json");

                using (var response = await hcl.PostAsync("api/Customer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cobj = JsonConvert.DeserializeObject<customer>(apiResponse);
                }
            }
            HttpContext.Session.SetString("reg","Registered Successfully");
            return RedirectToAction("login");
        }
        string baseurl="https://localhost:5001/";
        string baseurl2="https://localhost:5003/";
        string baseurl3="https://localhost:5011/";
        public async Task<IActionResult> searchflights(IFormCollection f){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            string From=f["From"];
            string To=f["To"];
            ViewBag.From=f["From"];
            ViewBag.To=f["To"];
            List<Flight> fd=new List<Flight>();
            using(var client =new HttpClient()){
                client.BaseAddress=new Uri(baseurl2);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("api/Book/Flights");
                if(res.IsSuccessStatusCode){
                    var FlightResponse=res.Content.ReadAsStringAsync().Result;
                    fd=JsonConvert.DeserializeObject<List<Flight>>(FlightResponse);
                }
            }
            List<Flight> fpart=new List<Flight>();
            foreach(Flight ft in fd){
                if(ft.Source==From && ft.Dest==To){
                    fpart.Add(ft);
                }
            }
            return View(fpart);
        }
        public async Task<IActionResult> GetAllFlights(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            string cname=HttpContext.Session.GetString("cname");
            ViewBag.cname=cname;
            List<Flight> fd=new List<Flight>();
            using(var client =new HttpClient()){
                client.BaseAddress=new Uri(baseurl2);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("api/Book/Flights");
                if(res.IsSuccessStatusCode){
                    var FlightResponse=res.Content.ReadAsStringAsync().Result;
                    fd=JsonConvert.DeserializeObject<List<Flight>>(FlightResponse);
                }
                return View(fd);
            }
        }
        public async Task<IActionResult> GetAllBookings(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            List<Book> bd=new List<Book>();
            int id=Convert.ToInt32(HttpContext.Session.GetInt32("cid"));
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5003/api/Book/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bd = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }
            return View(bd);
            
        }
        public async Task<IActionResult> Book(int id){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            Flight f1=new Flight();
            List<Book> bs=new List<Book>();
            int cid=Convert.ToInt32(HttpContext.Session.GetInt32("cid"));
            using(var httpClient=new HttpClient()){
                httpClient.BaseAddress=new Uri(baseurl2);
                using(var response=await httpClient.GetAsync("api/Book/Flights/"+id)){
                    string apiResponse=await response.Content.ReadAsStringAsync();
                    f1=JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            using(var httpClient=new HttpClient()){
                httpClient.BaseAddress=new Uri(baseurl2);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage res=await httpClient.GetAsync("api/Book");
                if(res.IsSuccessStatusCode){
                    var Response=res.Content.ReadAsStringAsync().Result;
                    bs=JsonConvert.DeserializeObject<List<Book>>(Response);
                }
            }
            Book b1=new Book();
            if(bs.Any()){
                int mid=bs.Max(x=>x.Bid);
                b1.Bid=mid+1;
            }
            else{
                b1.Bid=1;
            }
            b1.Fid=f1.Fid;
            b1.Cid=Convert.ToInt32(HttpContext.Session.GetInt32("cid"));
            return View(b1);

        }
        public void checkbook(Flight f1,Book b1){
            if(b1.Nop<=0){
                throw new NegativeValueException("passangers count must be greater than 0");
            }
            else if(f1.Seat<=b1.Nop){
                HttpContext.Session.SetInt32("fcap",f1.Seat);
                HttpContext.Session.SetInt32("bnop",b1.Nop);
                //ViewBag.fcap="available tickets are "+f1.Seat+" which are less than the requirement "+ b1.Nop;
                ViewBag.bnop=b1.Nop;
                throw new InsufficientPassangers("available tickets are "+f1.Seat+" which are less than the requirement "+ b1.Nop); 
            }
        }
        [HttpPost]
        public async Task<IActionResult> Book(Book b1){
            Flight f1=new Flight();
            Book b2=new Book();
            int id=b1.Fid;

            using(var httpClient=new HttpClient()){
                httpClient.BaseAddress=new Uri(baseurl2);
                using(var response=await httpClient.GetAsync("api/Book/Flights/"+id)){
                    string apiResponse=await response.Content.ReadAsStringAsync();
                    f1=JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            b1.Amount=b1.Nop*f1.Price;
            // if(b1.Nop<=0){
            //     ViewBag.no="passangers count must be greater than 0";
            //     return View();
            // }
            // else if(f1.Seat>=b1.Nop){
            //     HttpContext.Session.SetInt32("fcap",f1.Seat);
            //     HttpContext.Session.SetInt32("bnop",b1.Nop);
            //     ViewBag.fcap="available tickets are "+f1.Seat+" which are less than the requirement "+ b1.Nop;
            //     ViewBag.bnop=b1.Nop;
            //     return View();
            // }
            try{
                checkbook(f1,b1);
            }
            catch(Exception e){
                ViewBag.no=e.Message;
                return View();
            }
            f1.Seat-=b1.Nop;
            using(var httpClient=new HttpClient()){
                httpClient.BaseAddress=new Uri(baseurl2);
                StringContent content = new StringContent(JsonConvert.SerializeObject(b1), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Book", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b2 = JsonConvert.DeserializeObject<Book>(apiResponse);
                }
            }
            Flight f2 = new Flight();
            using (var httpClient = new HttpClient())
            {   
                int id1 = f1.Fid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(f1), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:5001/api/Flight/" + id1, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    f2 = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            HttpContext.Session.SetInt32("bid",b1.Bid);
            return RedirectToAction("bookdet");
            
        } 
        public IActionResult bookingfailed(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            ViewBag.fcap=Convert.ToInt32(HttpContext.Session.GetInt32("fcap"));
            ViewBag.bnop=HttpContext.Session.GetInt32("bnop");
            return View();
        }
        public async Task<IActionResult> bookdet(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            Book b1=new Book();
            int id=Convert.ToInt32(HttpContext.Session.GetInt32("bid"));
            using(var httpClient=new HttpClient()){
                httpClient.BaseAddress=new Uri(baseurl2);
                using(var response=await httpClient.GetAsync("api/Book/bid/"+id)){
                    string apiResponse=await response.Content.ReadAsStringAsync();
                    b1=JsonConvert.DeserializeObject<Book>(apiResponse);
                }
            }
            return View(b1);
        }
        


        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

    }
}