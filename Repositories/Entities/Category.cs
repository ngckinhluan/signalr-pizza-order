using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CategoryID")]
    public required int CategoryId { get; set; }

    [Required(ErrorMessage = "CategoryName is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the CategoryName is 255 characters.")]
    public required string CategoryName { get; set; }

    [Column("Description")]
    [MaxLength(255, ErrorMessage = "Maximum length for the CategoryName is 255 characters.")]
    public string? Description { get; set; }
    
    
    public virtual ICollection<Product>? Products { get; set; }
}