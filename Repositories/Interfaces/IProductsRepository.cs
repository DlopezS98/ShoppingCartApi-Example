using ShoppingCart.Models;

namespace ShoppingCart.Repositories.Interfaces;

public interface IProductsRepository
{
    Task<List<Product>> GetProducts();
    Task<Product> GetById(Guid id);
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Guid id);
}