using ShopSphere.Models;

namespace ShopSphere.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);

        Task AddAsync(Product product);
        void update(Product product);
        void Delete(Product product);
        Task SaveChangesAsync();
   }
}




