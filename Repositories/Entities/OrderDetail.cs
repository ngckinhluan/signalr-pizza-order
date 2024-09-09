using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;

public class OrderDetail
{
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }
    
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
}