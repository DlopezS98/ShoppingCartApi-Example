using ShoppingCart.DTOs;
using ShoppingCart.Models;
using ShoppingCart.Repositories.Interfaces;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Services;

public class ProductsService : IProductsService
{

    private readonly IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<ProductDTO> Create(CreateProductDTO productDto)
    {
        Guid id = Guid.NewGuid();
        Product product = new()
        {
            Id = id,
            Name = productDto.Name,
            Description = productDto.Description,
            CategoryIds = productDto.CategoryIds,
            CreatedAt = DateTime.UtcNow,
            IsDisabled = false,
            Price = productDto.Price,
            Stock = productDto.Stock
        };

        await _productsRepository.Create(product);

        return MapEntityToDto(product);
    }

    public async Task<bool> Delete(Guid id)
    {
        await _productsRepository.Delete(id);
        return true;
    }

    public async Task<ProductDTO> GetById(Guid id)
    {
        Product product = await _productsRepository.GetById(id);
        return MapEntityToDto(product);
    }

    public async Task<ProductDTO> Update(Guid id, UpdateProductDTO productDto)
    {
        var product = await _productsRepository.GetById(id);
        if (product is null) throw new Exception("Product not found");

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.CategoryIds = productDto.CategoryIds;
        product.UpdatedAt = DateTime.UtcNow;

        await _productsRepository.Update(product);

        return MapEntityToDto(product);
    }

    public async Task<List<ProductDTO>> GetProducts()
    {
        var products = await _productsRepository.GetProducts();
        return products.Select(MapEntityToDto).ToList();
    }

    private ProductDTO MapEntityToDto(Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryIds = product.CategoryIds,
            CreatedAt = product.CreatedAt,
            IsDisabled = product.IsDisabled,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}
