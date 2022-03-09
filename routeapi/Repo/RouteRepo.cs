using routeapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace routeapi.Repo{
    public class RouteRepo : IRouteRepo
    {
        Route r=new Route();

        public void AddRoute(Route r)
        {
            r.AddRoute(r);
        }

        public void DeleteRoute(int id)
        {
            r.DeleteRoute(id);
        }

        public Route GetRouteById(int id)
        {
            return r.GetRouteById(id);
        }

        public List<Route> GetRoutes()
        {
            return r.GetRoutes();
        }
    }
}