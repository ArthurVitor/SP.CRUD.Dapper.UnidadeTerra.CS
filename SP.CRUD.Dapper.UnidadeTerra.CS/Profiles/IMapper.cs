using SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;
using SP.CRUD.Dapper.UnidadeTerra.CS.Models;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Profiles;

public interface IMapper
{
    Product CreateProductDtoToProduct(CreateProductDto productDto);

    ListProductDto ProductToListProductDto(Product product);

    IEnumerable<ListProductDto> ProductsToListProductDtos(IEnumerable<Product> products);

    Product UpdateProducDtoToProduct(UpdateProductDto productDto);
}