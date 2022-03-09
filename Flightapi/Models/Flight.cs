using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flightapi.Models
{
    public class Flight:IFlight<Flight>
    {
        public int Fid { get; set; }
        public string Fname { get; set; }
        public string Source { get; set; }
        public string Dest { get; set; }
        public DateTime? Dtime { get; set; }
        public DateTime? Atime { get; set; }
        public int Seat { get; set; }
        public int Price { get; set; }
        public static List<Flight> flght = new List<Flight>();
        public Flight()
        {

        }
        public Flight(int fid,string fname,string source, string dest,DateTime dtime,DateTime atime,int seat,int price)
        {
            Fid = fid;
            Fname = fname;
            Source=source;
            Dest=dest;
            Dtime=dtime;
            Atime=atime;
            Seat = seat;
            Price = price;
        }
        public List<Flight> GetFlights()
        {
            
            return flght;
        }
        public void AddFlight(Flight f)
        {
        flght.Add(f);

        }
        public void DeleteFlight(int id)
        {
            Flight f = GetFlightById(id);
            flght.Remove(f);
        }
        public  Flight GetFlightById(int id)
        {
            flght = GetFlights();
            Flight f = flght.Where(x=>x.Fid==id).FirstOrDefault();
            return f;
        }
    }
}
