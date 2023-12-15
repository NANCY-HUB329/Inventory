using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inventory.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string OrderQuantity { get; set; }
        public int UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
