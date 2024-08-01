using Microsoft.AspNetCore.Mvc;
using SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Services.Interface;

public interface IProductService
{
    Task<IActionResult> CreateProduct(CreateProductDto productDto);

    Task<IActionResult> GetAllProducts(string name, double minPrice, double maxPrice, string category);

    Task<IActionResult> UpdateProduct(int id, UpdateProductDto productDto);

    Task<IActionResult> DeleteProduct(int id);
}