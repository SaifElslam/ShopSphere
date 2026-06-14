namespace ShopSphere.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }
    }
}
