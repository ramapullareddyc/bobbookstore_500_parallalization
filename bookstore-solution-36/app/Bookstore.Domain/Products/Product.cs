using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Products;

[Table("Product_mod", Schema = "database-1_dbo")]
public class Product
{
    [Key]
    [Column("ProductID_mod")]
    public int ProductID { get; set; }

    [Required]
    [StringLength(15)]
    [Column("Name_mod")]
    public string Name { get; set; }

    [Required]
    [StringLength(256)]
    [Column("ProductNumber_mod")]
    public string ProductNumber { get; set; }

    [Required]
    [Column("SafetyStockLevel_mod")]
    public int SafetyStockLevel { get; set; }
}