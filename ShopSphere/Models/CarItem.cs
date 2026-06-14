namespace ShopSphere.Models
{
    public class CarItem
    {
        public int Id { get; set; } 
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product products { get; set; } = null!; 
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
    }


    }

