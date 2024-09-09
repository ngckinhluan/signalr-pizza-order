using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;
public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int AccountId { get; set; }

    [Required(ErrorMessage = "Username is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Password is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the password is 60 characters.")]
    public required string Password { get; set; }
    
    [Required(ErrorMessage = "FullName is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the FullName is 255 characters.")]
    public required string FullName { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Type is 255 characters.")]
    public string? Type { get; set; }
}