using Microsoft.AspNetCore.Mvc;
using SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;
using SP.CRUD.Dapper.UnidadeTerra.CS.Models;
using SP.CRUD.Dapper.UnidadeTerra.CS.Profiles;
using SP.CRUD.Dapper.UnidadeTerra.CS.Repositories.Interfaces;
using SP.CRUD.Dapper.UnidadeTerra.CS.Services.Interface;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        try
        {
            Product product = await _productRepository.CreateProduct(_mapper.CreateProductDtoToProduct(productDto));
            return new OkObjectResult(_mapper.ProductToListProductDto(product));
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        
        
    }

    public async Task<IActionResult> GetAllProducts(string name, double minPrice, double maxPrice, string category)
    {
        try
        {
            return new OkObjectResult(_mapper.ProductsToListProductDtos(await _productRepository.GetAllProducts(name, minPrice, maxPrice, category)));
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto productDto)
    {
        try
        {
            Product updatedProduct = _productRepository.UpdateProduct(id, _mapper.UpdateProducDtoToProduct(productDto));

            return new OkObjectResult(_mapper.ProductToListProductDto(updatedProduct));
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            _productRepository.DeleteProduct(id);
            return new NoContentResult();
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}