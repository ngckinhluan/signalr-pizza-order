using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;

[Table("Product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ProductId")]
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "ProductName is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the ProductName is 255 characters.")]
    [Column("ProductName")]
    public required string ProductName { get; set; }

    [Required(ErrorMessage = "QuantityPerUnit is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the QuantityPerUnit is 255 characters.")]
    [Column("QuantityPerUnit")]
    public required string QuantityPerUnit { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? UnitPrice { get; set; }

    [Required(ErrorMessage = "ProductImage is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the ProductImage is 255 characters.")]
    [Column("ProductImage")]
    public required string ProductImage { get; set; }

    [ForeignKey(nameof(Category))]
    [Column("CategoryId")]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(Supplier))]
    [Column("SupplierId")]
    public int SupplierId { get; set; }

    public virtual Category? Category { get; set; }
    public virtual Supplier? Supplier { get; set; }
    
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}