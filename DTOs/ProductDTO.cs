using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public List<Guid> CategoryIds { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public List<string> CategoryNames { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsDisabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateProductDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Guid> CategoryIds { get; set; } = new();
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Stock { get; set; }
}

public class UpdateProductDTO {
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Guid> CategoryIds { get; set; } = new();
}