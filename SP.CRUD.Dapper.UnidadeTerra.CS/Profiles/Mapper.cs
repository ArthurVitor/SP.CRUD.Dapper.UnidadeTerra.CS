using System.Diagnostics;
using SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;
using SP.CRUD.Dapper.UnidadeTerra.CS.Models;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Profiles;

public class Mapper : IMapper
{
    public Product CreateProductDtoToProduct(CreateProductDto productDto)
    {
        return new Product()
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Price = productDto.Price
        };
    }

    public ListProductDto ProductToListProductDto(Product product)
    {
        return new ListProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price
        };
    }

    public IEnumerable<ListProductDto> ProductsToListProductDtos(IEnumerable<Product> products)
    {
        return products.Select(product => new ListProductDto()
        {
            Id = product.Id,
            Category = product.Category,
            Price = product.Price,
            Name = product.Name
        });
    }

    public Product UpdateProducDtoToProduct(UpdateProductDto productDto)
    {
        return new Product()
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Price = productDto.Price
        };
    }
}