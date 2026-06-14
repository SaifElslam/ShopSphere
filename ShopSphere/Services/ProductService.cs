using ShopSphere.Models;
using ShopSphere.Repositories;
namespace ShopSphere.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;

        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
             _repository.AddAsync(product);
             await _repository.SaveChangesAsync();
            return product;
        }
        public async Task<bool> UpdateAsync(int id ,Product product)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.price = product.price;
            existing.StokeQuantity = product.StokeQuantity;
            existing.ImageUrl = product.ImageUrl;
            existing.categoryId = product.categoryId;

            _repository.update(existing);
            await _repository.SaveChangesAsync();
            return true;
        }
        public async Task <bool> DeleteAsync (int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return false;

            }  _repository.Delete(product);
                await _repository.SaveChangesAsync();

                return true;
            }
        }

    }

