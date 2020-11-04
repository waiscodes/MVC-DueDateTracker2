using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDueDateTracker.Models
{
    [Table("author")]
    public class Author
    {
        //public Author()
        //{
        //    EMailAddresses = new HashSet<Book>();
        //}

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        //[InverseProperty(nameof(Models.EMailAddress.Person))]
        //public virtual ICollection<EMailAddress> EMailAddresses { get; set; }
    }
}
