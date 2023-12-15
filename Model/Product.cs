using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductDescription { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
