using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookstore.Domain.Books;

namespace Bookstore.Domain.Orders
{
    [Table("OrderItem_mod", Schema = "database-1_dbo")]
    public class OrderItem : Entity
    {
        // This private constructor is required by EF Core
        private OrderItem() { }

        public OrderItem(Order order, Book book, int quantity)
        {
            OrderId = order.Id;
            Order = order;
            BookId = book.Id;
            Book = book;
            Quantity = quantity;
        }

        [Column("OrderId_mod")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Column("BookId_mod")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Column("Quantity_mod")]
        public int Quantity { get; set; }
    }
}