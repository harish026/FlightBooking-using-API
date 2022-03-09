using System;
using System.Collections.Generic;
using System.Linq;

namespace routeapi.Models
{
    public partial class Route
    {
        public int Routeid { get; set; }
        public int? Flightid { get; set; }
        public string Routedesc { get; set; }
        public static List<Route> rd = new List<Route>();
        public Route()
        {

        }
        public Route(int rid,int fid,string rdes){
            Routeid=rid;
            Flightid=fid;
            Routedesc=rdes;
        }
        public List<Route> GetRoutes()
        {
            
            return rd;
        }
        public Route GetRouteById(int id){
            rd=GetRoutes();
            Route r=rd.Where(x=>x.Flightid==id).FirstOrDefault();
            return r;
        }
        public void AddRoute(Route r){
            rd.Add(r);
        }
        public void DeleteRoute(int id){
            Route r=GetRouteById(id);
            rd.Remove(r);
        }


    }
}
