using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int CustomerID { get; set; }

    [Required(ErrorMessage = "Password is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Password is 255 characters.")]
    public required string Password { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the ContactName is 255 characters.")]
    public string? ContactName { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Address is 255 characters.")]
    public string? Address { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Phone is 255 characters.")]
    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}