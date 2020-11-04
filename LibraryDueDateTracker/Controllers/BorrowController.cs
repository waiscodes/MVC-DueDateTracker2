using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDueDateTracker.Controllers
{
    public class BorrowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void CreateBorrow(string bookId)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Borrows.Add(new Borrow()
                {
                    BookID = int.Parse(bookId),
                    CheckedOutDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14)
                });
                context.SaveChanges();
            }
        }

        public void ReturnBorrowByID(string bookId)
        {
            using (LibraryContext context = new LibraryContext())
            {
                // Update old book ID
            }
        }

        public void ExtendDueDateForBorrowByID(string bookID)
        {
            using (LibraryContext context = new LibraryContext())
            {
                // Create a new Borrow or update existing one? 
            }
        }
    }
}
