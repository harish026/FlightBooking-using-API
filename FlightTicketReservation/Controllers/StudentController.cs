using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketReservation.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace FlightTicketReservation.Controllers{
    public class StudentController:Controller{

        public IActionResult Addnumbers(){
            return View();
        }
        [HttpPost]
        public IActionResult Addnumbers(IFormCollection f){
            // int a=Convert.ToInt32(f["first"]);
            // int b=Convert.ToInt32(f["second"]);
            int a=Convert.ToInt32(Request.Form["first"]);
            int b=Convert.ToInt32(Request.Form["second"]);
            int c=a+b;
             ViewBag.result=c;
             return View();
            // HttpContext.Session.SetString("result",c.ToString());

            // return RedirectToAction("res");
        }
        public IActionResult res(){
            ViewBag.result=HttpContext.Session.GetString("result");
            return View();
        }
   }
}