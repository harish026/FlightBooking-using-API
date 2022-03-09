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
//using Bookapi.Models;

namespace Flightbookingapi.Controllers
{
    public class AdminController : Controller{

        public IActionResult login(){
            return View();
        }
         public void check(admin ad){
            if(ad.name=="admin" && ad.password=="1234"){
                return ;
            }
            else{
                throw new AccountNotFound("invalid admin credentials :/");
            }
        }
        [HttpPost]
        public IActionResult login(admin ad){
             try{
                
                check(ad);
                HttpContext.Session.SetInt32("aid",12);
                HttpContext.Session.SetString("adname","admin");
            }
            catch(Exception e){
                ViewBag.loginerr=e.Message;
                return View();
            }
            return RedirectToAction("home");
        }
         public IActionResult home(){
             if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            ViewBag.adname=HttpContext.Session.GetString("adname");
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View();
        }

        string baseurl="https://localhost:5001/";
        string baseurl2="https://localhost:5003/";
        string baseurl3="https://localhost:5011/";

        public async Task<IActionResult> GetAllFlights(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            List<Flight> fd=new List<Flight>();
            using(var client =new HttpClient()){
                client.BaseAddress=new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("api/Flight");
                if(res.IsSuccessStatusCode){
                    var FlightResponse=res.Content.ReadAsStringAsync().Result;
                    fd=JsonConvert.DeserializeObject<List<Flight>>(FlightResponse);
                }
                return View(fd);
            }
        }
        
        public async Task<IActionResult> GetAllCustomers(){
             if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            List<customer> cd=new List<customer>();
            using(var client =new HttpClient()){
                client.BaseAddress=new Uri(baseurl3);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res=await client.GetAsync("api/Customer");
                if(res.IsSuccessStatusCode){
                    var FlightResponse=res.Content.ReadAsStringAsync().Result;
                    cd=JsonConvert.DeserializeObject<List<customer>>(FlightResponse);
                }
                return View(cd);
            }
        }
        public IActionResult Create(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Flight f1){
            Flight fobj=new Flight();
            using(var hcl=new HttpClient()){
                hcl.BaseAddress=new Uri(baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(f1), Encoding.UTF8, "application/json");

                using (var response = await hcl.PostAsync("api/Flight", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fobj = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return RedirectToAction("GetAllFlights");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            Flight f = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(f);
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Flight f)
        {
            Flight f1 = new Flight();
            using (var httpClient = new HttpClient())
            {
                int id = f.Fid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:5001/api/Flight/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    f1 = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return RedirectToAction("GetAllFlights");
        }
        
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            TempData["Flid"]=id;
            Flight f = new Flight();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/flight/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    f = JsonConvert.DeserializeObject<Flight>(apiResponse);
                }
            }
            return View(f);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Flight f)
        {
            int flid = Convert.ToInt32(TempData["flid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/Flight/" + flid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetAllFlights");
        }


        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}