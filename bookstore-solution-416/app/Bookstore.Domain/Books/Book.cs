using System;
using System.ComponentModel.DataAnnotations.Schema;
using Bookstore.Domain.ReferenceData;

namespace Bookstore.Domain.Books
{
    [Table("Book_mod", Schema = "database-1_dbo")]
    public class Book : Entity
    {
        public const int LowBookThreshold = 5;

        public Book(
            string name, 
            string author, 
            string ISBN, 
            int publisherId, 
            int bookTypeId, 
            int genreId,
            int conditionId,
            decimal price,
            int quantity, 
            int? year = null,
            string? summary = null,
            string? coverImageUrl = null)
        {
            Name = name;
            Author = author;
            this.ISBN = ISBN;
            PublisherId = publisherId;
            BookTypeId = bookTypeId;
            GenreId = genreId;
            ConditionId = conditionId;
            Price = price;
            Quantity = quantity;
            Year = year;
            Summary = summary;
            CoverImageUrl = coverImageUrl;
        }

        [Column("Name_mod")]
        public string Name { get; set; }

        [Column("Author_mod")]
        public string Author { get; set; }

        [Column("Year_mod")]
        public int? Year { get; set; }

        [Column("ISBN_mod")]
        public string ISBN { get; set; }

        public ReferenceDataItem Publisher { get; set; }
        [Column("PublisherId_mod")]
        public int PublisherId { get; set; }

        public ReferenceDataItem BookType { get; set; }
        [Column("BookTypeId_mod")]
        public int BookTypeId { get; set; }

        public ReferenceDataItem Genre { get; set; }
        [Column("GenreId_mod")]
        public int GenreId { get; set; }

        public ReferenceDataItem Condition { get; set; }
        [Column("ConditionId_mod")]
        public int ConditionId { get; set; }

        [Column("CoverImageUrl_mod")]
        public string? CoverImageUrl { get; set; }

        [Column("Summary_mod")]
        public string? Summary { get; set; }

        [Column("Price_mod")]
        public decimal Price { get; set; }

        [Column("Quantity_mod")]
        public int Quantity { get; set; }

        public bool IsInStock => Quantity > 0;

        public bool IsLowInStock => Quantity <= LowBookThreshold;

        public void ReduceStockLevel(int quantity)
        {
            Quantity = Math.Max(Quantity - quantity, 0);
        }
    }
}