using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using routeapi.Models;

namespace routeapi.Repo
{
    public interface IRouteRepo
    {
        public void AddRoute(Route r);
        public void DeleteRoute(int id);
        public List<Route> GetRoutes();
        public Route GetRouteById(int id);

    }  
}
