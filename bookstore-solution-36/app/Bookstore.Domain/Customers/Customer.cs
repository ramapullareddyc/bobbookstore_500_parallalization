using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Customers
{
    [Table("Customer_mod", Schema = "database-1_dbo")]
    public class Customer : Entity
    {
        [Column("Sub_mod")]
        public string Sub { get; set; }

        [Column("Username_mod")]
        public string? Username { get; set; }

        [Column("FirstName_mod")]
        public string? FirstName { get; set; }

        [Column("LastName_mod")]
        public string? LastName { get; set; }

        [Column("FullName_mod")]
        public string FullName { get; set; }

        [Column("Email_mod")]
        public string? Email { get; set; }

        [Column("DateOfBirth_mod")]
        public DateTime? DateOfBirth { get; set; }

        [Column("Phone_mod")]
        public string? Phone { get; set; }
    }
}