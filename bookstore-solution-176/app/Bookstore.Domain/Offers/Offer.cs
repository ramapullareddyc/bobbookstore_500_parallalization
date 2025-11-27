using System;
using System.ComponentModel.DataAnnotations.Schema;
using Bookstore.Domain.Customers;
using Bookstore.Domain.ReferenceData;

namespace Bookstore.Domain.Offers
{
    [Table("Offer_mod", Schema = "database-1_dbo")]
    public class Offer : Entity
    {
        public Offer(
            int customerId,
            string bookName,
            string author,
            string ISBN,
            int bookTypeId,
            int conditionId,
            int genreId,
            int publisherId,
            decimal bookPrice)
        {
            CustomerId = customerId;
            BookName = bookName;
            Author = author;
            this.ISBN = ISBN;
            BookTypeId = bookTypeId;
            ConditionId = conditionId;
            GenreId = genreId;
            PublisherId = publisherId;
            BookPrice = bookPrice;
        }

        [Column("Author_mod")]
        public string Author { get; set; }

        [Column("ISBN_mod")]
        public string ISBN { get; set; }

        [Column("BookName_mod")]
        public string BookName { get; set; }

        [Column("FrontUrl_mod")]
        public string? FrontUrl { get; set; }

        public ReferenceDataItem Genre { get; set; }
        [Column("GenreId_mod")]
        public int GenreId { get; set; }

        public ReferenceDataItem Condition { get; set; }
        [Column("ConditionId_mod")]
        public int ConditionId { get; set; }

        public ReferenceDataItem Publisher { get; set; }
        [Column("PublisherId_mod")]
        public int PublisherId { get; set; }

        public ReferenceDataItem BookType { get; set; }
        [Column("BookTypeId_mod")]
        public int BookTypeId { get; set; }

        [Column("Summary_mod")]
        public string? Summary { get; set; }

        [Column("OfferStatus_mod")]
        public OfferStatus OfferStatus { get; set; } = OfferStatus.PendingApproval;

        [Column("Comment_mod")]
        public string? Comment { get; set; }

        public Customer Customer { get; set; }
        [Column("CustomerId_mod")]
        public int CustomerId { get; set; }

        [Column("BookPrice_mod")]
        public decimal BookPrice { get; set; }
    }
}