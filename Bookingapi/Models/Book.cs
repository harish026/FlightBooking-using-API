using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Models
{
    public class Book
    {
        public int Bid { get; set; }
        public string name{get;set;}
        public DateTime createdAt{get;set;}
        public int Fid { get; set; }
        public int Cid { get; set; }
        public int Nop { get; set; }
        public float Amount { get; set; }

        public static List<Book> booking = new List<Book>();
        //booking.Add("1","harish","121212");
        
        public Book()
        {

        }

        public Book(int bid,string bname,DateTime cd, int fid, int cid, int nop, float amt)
        {
            Bid=bid;
            name=bname;
            createdAt=cd;
            Fid=fid;
            Cid=cid;
            Nop=nop;
            Amount=amt;
        }

        public List<Book> GetBookings()
        {
           
            return booking;
        }
        public List<Book> GetBookById(int id)
        {
            // Book b = booking.Where(x => x.Cid == id).FirstOrDefault();
            // return b;
            List<Book> bs=new List<Book>();
            foreach(var b in booking){
                if(b.Cid==id){
                    bs.Add(b);
                }
            }
            return bs;
        }

        public void AddBooking(Book b)
        {
            booking.Add(b);

        }
        public Book GetById(int id){
            Book b = booking.Where(x => x.Bid == id).FirstOrDefault();
            return b;
        }

        public void DeleteBooking(int id)
        {
            Book b = GetById(id);
            booking.Remove(b);
        }

        

    }

}
    

