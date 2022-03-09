using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketReservation.Models;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

//flights
//routes

namespace FlightTicketReservation.Controllers{
    public class AdminController:Controller{
        //databasetrainingContext db=new databasetrainingContext();
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly databasetrainingContext db;
        public AdminController(databasetrainingContext _db,IWebHostEnvironment _webHostEnvironment,IHttpContextAccessor _http){
            webHostEnvironment=_webHostEnvironment;
            httpContextAccessor=_http;
            db=_db;
        }

        public IActionResult login(){
            return View();
        }
        [HttpPost]
        public IActionResult login(admin ad){
            if(ad.name=="admin" && ad.password=="1234"){
                HttpContext.Session.SetInt32("aid",12);
                HttpContext.Session.SetString("adname","admin");
                return RedirectToAction("home");
            }
            else{
                return RedirectToAction("login");
            }
        }
        
        public IActionResult home(){
            ViewBag.adname=HttpContext.Session.GetString("adname");
            
            return View();
        }
        [Route("getflights")]
        public IActionResult getallFlights(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View(db.FlightDetails.ToList());
        }
        
        public IActionResult Create(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(dupflight f1){
            using(var db=new databasetrainingContext()){
                string fname=null;
                if(f1.Imagepath!=null){
                    string up=Path.Combine(webHostEnvironment.WebRootPath,"Images");
                    fname=f1.Imagepath.FileName;
                    string fp=Path.Combine(up,fname);
                    using(var filest=new FileStream(fp,FileMode.Create)){
                        f1.Imagepath.CopyTo(filest);
                    }
                    FlightDetail fd=new FlightDetail();
                    fd.Flightid=f1.Flightid;
                    fd.Flightname=f1.Flightname;
                    fd.Costperseat=f1.Costperseat;
                    fd.Departuretime=f1.Departuretime;
                    fd.Arrivaltime=f1.Arrivaltime;
                    fd.Destination=f1.Destination;
                    fd.Imagepath="~/images/"+fname;
                    fd.Source=f1.Source;
                    fd.Totalcapacity=f1.Totalcapacity;
                    db.FlightDetails.Add(fd);
                    db.SaveChanges();
                    return RedirectToAction("getallFlights");
                }
                else{
                    return View();
                }
            }
            // db.FlightDetails.Add(f1);
            // db.SaveChanges();
            // return RedirectToAction("getallFlights");
        }
       // [Route("flightEdit/{id}")]
        public IActionResult Edit(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            FlightDetail f1=db.FlightDetails.Find(id);
            return View(f1);
        }
        [HttpPost]
        public IActionResult Edit(FlightDetail f1){
            db.FlightDetails.Update(f1);
            db.SaveChanges();
            return RedirectToAction("getallFlights");
        }
        public IActionResult Details(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            FlightDetail f1=db.FlightDetails.Find(id);
            return View(f1);
        }
        public IActionResult Delete(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            FlightDetail f1=db.FlightDetails.Find(id);
            return View(f1);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteFlight(int id){
            FlightDetail f1=db.FlightDetails.Find(id);
            db.FlightDetails.Remove(f1);
            db.SaveChanges();
            return RedirectToAction("getallFlights");
        }
        public IActionResult getallRoutes(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View(db.RouteDetails.ToList());
        }
        public IActionResult routeCreate(){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult routeCreate(RouteDetail r1){
            db.RouteDetails.Add(r1);
            db.SaveChanges();
            return RedirectToAction("getallRoutes");
        }
        public IActionResult routeEdit(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            RouteDetail r1=db.RouteDetails.Find(id);
            return View(r1);
        }
        [HttpPost]
        public IActionResult routeEdit(RouteDetail r1){
            db.RouteDetails.Update(r1);
            db.SaveChanges();
            return RedirectToAction("getallRoutes");
        }
        public IActionResult routeDet(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            RouteDetail r1=db.RouteDetails.Find(id);
            return View(r1);
        }
        public IActionResult routeDelete(int id){
            if(HttpContext.Session.GetInt32("aid")==null){
                return RedirectToAction("login");
            }
            RouteDetail r1=db.RouteDetails.Find(id);
            return View(r1);
        }
        [HttpPost]
        [ActionName("routeDelete")]
        public IActionResult routeDeleteconf(int id){
            RouteDetail r1=db.RouteDetails.Find(id);
            db.RouteDetails.Remove(r1);
            db.SaveChanges();
            return RedirectToAction("getallRoutes");
        }
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}