namespace Inventory.Model.MyDTO
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
