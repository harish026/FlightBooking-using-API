using Bookapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookapi.Repo
{
    interface IBookrp
    {
        public void AddBooking(Book b);
        public void CancelBooking(int id);

        public List<Book> GetBookings();
        public List<Book> GetBookById(int id);
        public Book GetById(int id);

    }
}
