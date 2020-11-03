using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryDueDateTracker.Controllers
{
    public class BookController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public static List<Book> Books = new List<Book>();

        public IActionResult Create(int id, string title, string author, DateTime publicationDate, DateTime checkoutDate)
        {
            try
            {
                CreateBook(id, title.Trim(), author.Trim(), publicationDate, checkoutDate);
                ViewBag.Msg = "Book successfully added";
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
            }
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Books = Books;
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.bookSelected = GetBookById(id);
            return View();
        }

        public IActionResult Return(int id)
        {
            ExtendDueDateForBookByID(id);
            return RedirectToAction("List");
        }
        public IActionResult Extend(int id)
        {
            ReturnBookByID(id);
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            DeleteBookByID(id);
            return RedirectToAction("List");
        }

        public void CreateBook(int id, string title, string author, DateTime publicationDate, DateTime checkoutDate)
        {
            List<Book> anyIds = Books.Where(x => x.ID == id).ToList();

            if (!anyIds.Any())
            {
                Books.Add(new Book(id, title, author, publicationDate, checkoutDate));
            }
            else
            {
                throw new Exception("Id already exists bro");
            }
        }

        public Book GetBookById(int id)
        {
            Book bookFound = Books.Where(x => x.ID == id).SingleOrDefault();
            return bookFound;
        }
        public void ExtendDueDateForBookByID(int id)
        {
            DateTime newdueDate = DateTime.Now.AddDays(7);
            Book book = Books.Where(x => x.ID == id).Single();
            book.DueDate = newdueDate;
        }
        public void ReturnBookByID(int id)
        {
            DateTime todaysDate = DateTime.Now;
            Book book = Books.Where(x => x.ID == id).Single();
            book.ReturnDate = todaysDate;
        }
        public void DeleteBookByID(int id)
        {
            Books.Remove(GetBookById(id));
        }
    }
}
