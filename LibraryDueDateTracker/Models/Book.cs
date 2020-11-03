using System;
namespace LibraryDueDateTracker.Models
{
    public class Book
    {
        private int _id;
        public int ID => _id;

        private string _title;
        public string Title => _title;

        private string _author;
        public string Author => _author;

        private DateTime _publicationDate;
        public DateTime PublicationDate => _publicationDate;

        private DateTime _checkoutDate;
        public DateTime CheckOutDate => _checkoutDate;

        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book(int id, string title, string author, DateTime publicationDate, DateTime checkedOutDate)
        {
            _id = id;
            _title = title;
            _author = author;
            _publicationDate = publicationDate;
            _checkoutDate = checkedOutDate;

            DueDate = CheckOutDate.AddDays(14);
            ReturnDate = null;
        }
    }
}
