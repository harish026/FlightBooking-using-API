using Bookapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Repo
{
    public class Bookrp : IBookrp
    {
        Book b = new Book();

        public void AddBooking(Book b)
        {
            b.AddBooking(b);
        }

        public void CancelBooking(int id)
        {
            b.DeleteBooking(id);
        }

        public List<Book> GetBookById(int id)
        {
            return b.GetBookById(id);
        }

        public List<Book> GetBookings()
        {
            return b.GetBookings();
        }

        public Book GetById(int id)
        {
            return b.GetById(id);
        }
    }
}
