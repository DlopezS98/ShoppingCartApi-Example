using ShoppingCart.Models;
using ShoppingCart.Repositories.Interfaces;

namespace ShoppingCart.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products;

    public ProductsRepository()
    {
        _products = new List<Product>();
    }

    public Task Create(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task Delete(Guid id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product is null) throw new Exception("Product not found");
        
        _products.Remove(product);
        return Task.CompletedTask;
    }

    public Task<Product> GetById(Guid id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product is null) throw new Exception("Product not found");
        
        return Task.FromResult(product);
    }

    public Task<List<Product>> GetProducts()
    {
        return Task.FromResult(_products);
    }

    public Task Update(Product product)
    {
        var index = _products.FindIndex(x => x.Id == product.Id);
        if (index < 0) throw new Exception("Product not found");
        
        _products[index] = product;
        return Task.CompletedTask;
    }
}