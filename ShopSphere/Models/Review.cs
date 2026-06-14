namespace ShopSphere.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int rating { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}
