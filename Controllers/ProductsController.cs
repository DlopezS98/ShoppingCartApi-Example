using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // private readonly IProductService _productService;

    // public ProductsController(IProductService productService)
    // {
    //     _productService = productService;
    // }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        throw new ArgumentException("Not implemented method");
    }
}
