using Microsoft.AspNetCore.Mvc;
using SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;
using SP.CRUD.Dapper.UnidadeTerra.CS.Services.Interface;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
    {
        return await _productService.CreateProduct(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(string name, double minPrice, double maxPrice, string category)
    {
        return await _productService.GetAllProducts(name, minPrice, maxPrice, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
    {
        return await _productService.UpdateProduct(id, productDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return await _productService.DeleteProduct(id);
    }
}