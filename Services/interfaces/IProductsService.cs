using ShoppingCart.DTOs;

namespace ShoppingCart.Services.Interfaces;

public interface IProductsService
{
    Task<List<ProductDTO>> GetProducts();
    Task<ProductDTO> GetById(Guid id);
    Task<ProductDTO> Create(CreateProductDTO productDto);
    Task<ProductDTO> Update(Guid id, UpdateProductDTO productDto);
    Task<bool> Delete(Guid id);
}