using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DTOs;
using ShoppingCart.Services.Interfaces;

namespace ShoppingCart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet(Name = nameof(GetProducts))]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productsService.GetProducts();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO productDto)
    {
        var product = await _productsService.Create(productDto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productsService.GetById(id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductDTO productDto)
    {
        var product = await _productsService.Update(id, productDto);
        return Ok(product);
    }
}
