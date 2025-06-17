namespace MinimalAPIValidationDemo.Models
{
    public class OrderDTO
    {
        public required string CustomerName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
