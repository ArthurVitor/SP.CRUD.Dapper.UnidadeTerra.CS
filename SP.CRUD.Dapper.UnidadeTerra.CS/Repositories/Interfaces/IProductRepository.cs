using SP.CRUD.Dapper.UnidadeTerra.CS.Models;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> CreateProduct(Product product);

    Task<IEnumerable<Product>> GetAllProducts(string name, double minPrice, double maxPrice, string category);

    Product UpdateProduct(int id, Product product);

    void DeleteProduct(int id);
}