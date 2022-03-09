using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketReservation.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace FlightTicketReservation.Controllers{

    public class CustomerController:Controller{
        //databasetrainingContext db=new databasetrainingContext();
        private readonly databasetrainingContext db;
        public CustomerController(databasetrainingContext _db){
           db=_db;
        }
    
        public IActionResult login(){
            ViewBag.register=HttpContext.Session.GetString("msg");
            return View();
        }
        [HttpPost]
        public IActionResult login(CustomerDetail c1){
            //using(databasetrainingContext db)
            var customer=db.CustomerDetails.Where(x=>x.Customername.Equals(c1.Customername) && x.Password.Equals(c1.Password)).FirstOrDefault();
            if(customer!=null){
                HttpContext.Session.SetInt32("cid",customer.Customerid);
                HttpContext.Session.SetString("cusname",customer.Customername);
                return RedirectToAction("home");
            }
            else{
                return RedirectToAction("login");
            }
        }
        public IActionResult usernotfound(){
            return View();
        }
        public IActionResult home(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            string name=HttpContext.Session.GetString("cusname");
            ViewBag.name=name;
            return View();
        }
        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public IActionResult Register(CustomerDetail c1){
            db.CustomerDetails.Add(c1);
            db.SaveChanges();
            string msg="registered successfully";
            HttpContext.Session.SetString("msg",msg);
            return RedirectToAction("login");
        }
        public IActionResult getallFlights(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            return View(db.FlightDetails.ToList());
        }
        public IActionResult Details(int id){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            FlightDetail f1=db.FlightDetails.Find(id);
            return View(f1);
        }
        public IActionResult getindBookings(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            List<BookingDetail> bds=new List<BookingDetail>();
            int? cid=HttpContext.Session.GetInt32("cid");
            foreach(var b in db.BookingDetails){
                if(b.Customerid==cid){
                    bds.Add(b);
                }
            }
            return View(bds);
        }
        public IActionResult book(int id){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            BookingDetail b1=new BookingDetail();
            Random rnd=new Random();
            b1.Bookingid=rnd.Next();
            b1.Flightid=id;
            //RouteDetail r1=db.RouteDetails.Where(x=>x.Flightid==id).FirstOrDefault();
            //b1.Routeid=r1.Routeid;
            //b1.Routeid=db.RouteDetails.Where(x=>x.Flightid==id).Select(x=>x).SingleOrDefault().Routeid;
            var r1=db.RouteDetails.Where(x=>x.Flightid.Equals(id)).FirstOrDefault();
            if(r1==null){
                return RedirectToAction("noroute");
            }
            b1.Routeid=r1.Routeid;
            b1.Customerid=HttpContext.Session.GetInt32("cid");
            b1.Doj=DateTime.Now;
            return View(b1);
        }
       
        [HttpPost]
        public IActionResult book(BookingDetail b1){
            
            //db.BookingDetails.Add(b1);
            FlightDetail f1=db.FlightDetails.Find(b1.Flightid);
            b1.Totalvalue=b1.Numberofpassengers*f1.Costperseat;
            if(f1.Totalcapacity>=b1.Numberofpassengers){
                f1.Totalcapacity-=b1.Numberofpassengers;
                db.BookingDetails.Add(b1);
                db.SaveChanges();
                HttpContext.Session.SetInt32("bid",b1.Bookingid);
                return RedirectToAction("bookdet");
            }
            else{
                return RedirectToAction("bookingfailed");
            }
        }
        public IActionResult noroute(){
            return View();
        }
        public IActionResult bookdet(){
            int id=Convert.ToInt32( HttpContext.Session.GetInt32("bid"));
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            BookingDetail b1=db.BookingDetails.Find(id);
            return View(b1);
        }
        [Route("unsuccessfulbooking")]
        public IActionResult bookingfailed(){
            if(HttpContext.Session.GetInt32("cid")==null){
                return RedirectToAction("login");
            }
            return View();
        }
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}