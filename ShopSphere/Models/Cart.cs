namespace ShopSphere.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<CarItem> CartItems { get; set; } = new List<CarItem>();
    }
}
