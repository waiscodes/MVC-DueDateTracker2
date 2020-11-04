using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryDueDateTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDueDateTracker.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Create(string id, string title, string author, string publicationDate, string checkedOutDate)
        {
            if (id != null && title != null && author != null && publicationDate != null && checkedOutDate != null)
            {
                try
                {
                    CreateBook(id, title, author, publicationDate, checkedOutDate);
                    ViewBag.SuccessfulCreation = true;
                    ViewBag.Status = $"Successfully added book ID {id}";
                }
                catch (Exception e)
                {
                    ViewBag.SuccessfulCreation = false;
                    ViewBag.Status = $"An error occured. {e.Message}";
                }
            }

            return View();
        }

        public IActionResult List()
        {
            //ViewBag.Books = Books;
            return View();
        }

        public IActionResult Details(string id)
        {
            try
            {
                ViewBag.Book = GetBookByID(id);
            }
            catch
            {

            }
            return View();
        }

        public IActionResult Extend(string id)
        {
            //ExtendDueDateByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }

        public IActionResult Return(string id)
        {
            ReturnBookByID(id);
            return RedirectToAction("Details", new Dictionary<string, string>() { { "id", id } });
        }

        public IActionResult Delete(string id)
        {
            DeleteBookByID(id);
            return RedirectToAction("List");
        }

        public void CreateBook(string id, string title, string author, string publicationDate, string checkedOutDate)
        {
                using (LibraryContext context = new LibraryContext())
                {
                    context.Books.Add(new Book()
                    {
                        //AuthorID = int.Parse(id),
                        PublicationDate = DateTime.Parse(publicationDate.Trim())

                    });
                    context.SaveChanges();
                }
        }

        public Book GetBookByID(string id)
        {
            Book found;
            using (LibraryContext context = new LibraryContext())
            {
                found = context.Books.Where(x => x.ID == int.Parse(id)).SingleOrDefault();
            }
            return found;
        }

        public void ExtendDueDateForBorrowByID(string bookId)
        {
            BorrowController.ExtendDueDateForBorrowByID(bookId);
        }

        public void ReturnBookByID(string id)
        {
        }

        public void DeleteBookByID(string bookId)
        {
            using (LibraryContext context = new LibraryContext())
            {
                context.Books.Remove(GetBookByID(bookId));
                context.SaveChanges();
            }
        }

        public List<Book> GetBooks()
        {
            List<Book> booksList;
            using (LibraryContext context = new LibraryContext())
            {
                booksList = context.Books.ToList();
            }
            return booksList;
        }

        public List<Book> GetOverdueBooks()
        {
            List<Book> overdueBooks;
            using (LibraryContext context = new LibraryContext())
            {
                overdueBooks = context.Books.ToList();
                // Overdue books
            }
            return overdueBooks;
        }
    }
}