using Bookstore.Domain.Addresses;
using Bookstore.Domain.Authors;
using Bookstore.Domain.Books;
using Bookstore.Domain.Carts;
using Bookstore.Domain.Customers;
using Bookstore.Domain.Offers;
using Bookstore.Domain.Orders;
using Bookstore.Domain.Products;
using Bookstore.Domain.ReferenceData;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;

namespace Bookstore.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Offer> Offer { get; set; }

        public DbSet<Author> Author { get; set; }
        
        public DbSet<Product> Product { get; set; }


        public DbSet<ReferenceDataItem> ReferenceData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table and column mappings for Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.AddressLine1).HasColumnName("AddressLine1_mod");
                entity.Property(e => e.AddressLine2).HasColumnName("AddressLine2_mod");
                entity.Property(e => e.City).HasColumnName("City_mod");
                entity.Property(e => e.State).HasColumnName("State_mod");
                entity.Property(e => e.Country).HasColumnName("Country_mod");
                entity.Property(e => e.ZipCode).HasColumnName("ZipCode_mod");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId_mod");
                entity.Property(e => e.IsActive).HasColumnName("IsActive_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");
            });

            // Table and column mappings for Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.Name).HasColumnName("Name_mod");
                entity.Property(e => e.Author).HasColumnName("Author_mod");
                entity.Property(e => e.Year).HasColumnName("Year_mod");
                entity.Property(e => e.ISBN).HasColumnName("ISBN_mod");
                entity.Property(e => e.PublisherId).HasColumnName("PublisherId_mod");
                entity.Property(e => e.BookTypeId).HasColumnName("BookTypeId_mod");
                entity.Property(e => e.GenreId).HasColumnName("GenreId_mod");
                entity.Property(e => e.ConditionId).HasColumnName("ConditionId_mod");
                entity.Property(e => e.CoverImageUrl).HasColumnName("CoverImageUrl_mod");
                entity.Property(e => e.Summary).HasColumnName("Summary_mod");
                entity.Property(e => e.Price).HasColumnName("Price_mod");
                entity.Property(e => e.Quantity).HasColumnName("Quantity_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");

                // Relationships
                entity.HasOne(x => x.Publisher).WithMany().HasForeignKey(x => x.PublisherId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.BookType).WithMany().HasForeignKey(x => x.BookTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Condition).WithMany().HasForeignKey(x => x.ConditionId).OnDelete(DeleteBehavior.Restrict);
            });

            // Table and column mappings for Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.Sub).HasColumnName("Sub_mod");
                entity.Property(e => e.Username).HasColumnName("Username_mod");
                entity.Property(e => e.FirstName).HasColumnName("FirstName_mod");
                entity.Property(e => e.LastName).HasColumnName("LastName_mod");
                entity.Property(e => e.Email).HasColumnName("Email_mod");
                entity.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth_mod");
                entity.Property(e => e.Phone).HasColumnName("Phone_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");

                // Index
                entity.HasIndex(x => x.Sub).IsUnique();
            });

            // Table and column mappings for Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId_mod");
                entity.Property(e => e.AddressId).HasColumnName("AddressId_mod");
                entity.Property(e => e.DeliveryDate).HasColumnName("DeliveryDate_mod");
                entity.Property(e => e.OrderStatus).HasColumnName("OrderStatus_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");

                // Relationship
                entity.HasOne(x => x.Customer).WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            // Table and column mappings for ShoppingCart
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.CorrelationId).HasColumnName("CorrelationId_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");
            });

            // Table and column mappings for ShoppingCartItem
            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.ToTable("ShoppingCartItem_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.ShoppingCartId).HasColumnName("ShoppingCartId_mod");
                entity.Property(e => e.BookId).HasColumnName("BookId_mod");
                entity.Property(e => e.Quantity).HasColumnName("Quantity_mod");
                entity.Property(e => e.WantToBuy).HasColumnName("WantToBuy_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");
            });

            // Table and column mappings for OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.OrderId).HasColumnName("OrderId_mod");
                entity.Property(e => e.BookId).HasColumnName("BookId_mod");
                entity.Property(e => e.Quantity).HasColumnName("Quantity_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");
            });

            // Table and column mappings for Offer
            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.Author).HasColumnName("Author_mod");
                entity.Property(e => e.ISBN).HasColumnName("ISBN_mod");
                entity.Property(e => e.BookName).HasColumnName("BookName_mod");
                entity.Property(e => e.FrontUrl).HasColumnName("FrontUrl_mod");
                entity.Property(e => e.GenreId).HasColumnName("GenreId_mod");
                entity.Property(e => e.ConditionId).HasColumnName("ConditionId_mod");
                entity.Property(e => e.PublisherId).HasColumnName("PublisherId_mod");
                entity.Property(e => e.BookTypeId).HasColumnName("BookTypeId_mod");
                entity.Property(e => e.Summary).HasColumnName("Summary_mod");
                entity.Property(e => e.OfferStatus).HasColumnName("OfferStatus_mod");
                entity.Property(e => e.Comment).HasColumnName("Comment_mod");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId_mod");
                entity.Property(e => e.BookPrice).HasColumnName("BookPrice_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");

                // Relationships
                entity.HasOne(x => x.Publisher).WithMany().HasForeignKey(x => x.PublisherId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.BookType).WithMany().HasForeignKey(x => x.BookTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Condition).WithMany().HasForeignKey(x => x.ConditionId).OnDelete(DeleteBehavior.Restrict);
            });

            // Table and column mappings for Author
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author_mod", "database-1_dbo");
                entity.Property(e => e.BusinessEntityID).HasColumnName("BusinessEntityID_mod");
                entity.Property(e => e.NationalIDNumber).HasColumnName("NationalIDNumber_mod");
                entity.Property(e => e.LoginID).HasColumnName("LoginID_mod");
                entity.Property(e => e.JobTitle).HasColumnName("JobTitle_mod");
                entity.Property(e => e.BirthDate).HasColumnName("BirthDate_mod");
                entity.Property(e => e.MaritalStatus).HasColumnName("MaritalStatus_mod");
                entity.Property(e => e.Gender).HasColumnName("Gender_mod");
                entity.Property(e => e.HireDate).HasColumnName("HireDate_mod");
                entity.Property(e => e.VacationHours).HasColumnName("VacationHours_mod");
                entity.Property(e => e.ModifiedDate).HasColumnName("ModifiedDate_mod");
            });

            // Table and column mappings for Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product_mod", "database-1_dbo");
                entity.Property(e => e.ProductID).HasColumnName("ProductID_mod");
                entity.Property(e => e.Name).HasColumnName("Name_mod");
                entity.Property(e => e.ProductNumber).HasColumnName("ProductNumber_mod");
                entity.Property(e => e.SafetyStockLevel).HasColumnName("SafetyStockLevel_mod");
            });

            // Table and column mappings for ReferenceDataItem
            modelBuilder.Entity<ReferenceDataItem>(entity =>
            {
                entity.ToTable("ReferenceData_mod", "database-1_dbo");
                entity.Property(e => e.Id).HasColumnName("Id_mod");
                entity.Property(e => e.DataType).HasColumnName("DataType_mod");
                entity.Property(e => e.Text).HasColumnName("Text_mod");
                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBy_mod");
                entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn_mod");
                entity.Property(e => e.UpdatedOn).HasColumnName("UpdatedOn_mod");
            });

            // Boolean to integer conversions for PostgreSQL
            modelBuilder.Entity<Address>().Property(e => e.IsActive).HasConversion<int>();
            modelBuilder.Entity<ShoppingCartItem>().Property(e => e.WantToBuy).HasConversion<int>();

            PopulateDatabase(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}