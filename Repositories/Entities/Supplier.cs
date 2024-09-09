using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;

[Table("Supplier")]
public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SupplierId")]
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "CompanyName is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the CompanyName is 255 characters.")]
    [Column("CompanyName")]
    public required string CompanyName { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Address is 255 characters.")]
    [Column("Address")]
    public string? Address { get; set; }

    [Phone]
    [Column("Phone")]
    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}