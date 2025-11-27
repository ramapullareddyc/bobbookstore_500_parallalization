using System.ComponentModel.DataAnnotations.Schema;
using Bookstore.Domain.Books;

namespace Bookstore.Domain.Carts
{
    [Table("ShoppingCartItem_mod", Schema = "database-1_dbo")]
    public class ShoppingCartItem : Entity
    {
        // An empty constructor is required by EF Core
        private ShoppingCartItem() { }

        public ShoppingCartItem(ShoppingCart shoppingCart, int bookId, int quantity, bool wantToBuy)
        {
            ShoppingCartId = shoppingCart.Id;
            ShoppingCart = shoppingCart;
            BookId = bookId;
            Quantity = quantity;
            WantToBuy = wantToBuy;
        }

        [Column("ShoppingCartId_mod")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        [Column("BookId_mod")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Column("Quantity_mod")]
        public int Quantity { get; set; }

        [Column("WantToBuy_mod")]
        public bool WantToBuy { get; set; }
    }
}