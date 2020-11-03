using System;
namespace LibraryDueDateTracker.Models
{
    public class Book
    {
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
        }
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
        }
        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
        }
        private DateTime _publicationDate;
        public DateTime PublicationDate
        {
            get
            {
                return _publicationDate;
            }
        }
        private DateTime _checkoutDate;
        public DateTime CheckOutDate
        {
            get
            {
                return _checkoutDate;
            }
        }

        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book(int id, string title, string author, DateTime publicationDate, DateTime checkoutDate)
        {
            _id = id;
            _title = title;
            _author = author;
            _publicationDate = publicationDate;
            _checkoutDate = checkoutDate;

            DueDate = CheckOutDate.AddDays(14);
            ReturnDate = null;
        }
    }
}
