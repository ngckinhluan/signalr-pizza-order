using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;
[Table("Order")]
public class Order
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderId")]
        public required int OrderId { get; set; }

        public DateOnly? OrderDate { get; set; }
    
        public DateOnly? RequiredDate { get; set; }
    
        public DateOnly? ShippedDate { get; set; }
    
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Freight { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length for the ShipAddress is 255 characters.")]
        [Column("ShipAddress")]
        public string? ShipAddress { get; set; }
        
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    
      
    
       
}