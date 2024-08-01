using System.Data;
using System.Data.SqlClient;
using Dapper;
using SP.CRUD.Dapper.UnidadeTerra.CS.Models;
using SP.CRUD.Dapper.UnidadeTerra.CS.Proxy;
using SP.CRUD.Dapper.UnidadeTerra.CS.Repositories.Interfaces;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SqlConnection _connection;

    public ProductRepository(DbConnectionProxy connectionProxy)
    {
        _connection = connectionProxy.GetConnection();
    }
    
    public async Task<Product> CreateProduct(Product product)
    {
        var productId = await _connection.ExecuteScalarAsync<int>("INSERT INTO [Product] VALUES(@Name, @Price, @Category);SELECT CAST(scope_identity() AS INT)", new
        {
            Name = product.Name,
            Price = product.Price,
            Category = product.Category
        });
        product.Id = productId;
        
        return product;
    }

    public Task<IEnumerable<Product>> GetAllProducts(string name, double minPrice, double maxPrice, string category)
    {
        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("p_name", name);
        dynamicParameters.Add("p_price_min", minPrice);
        dynamicParameters.Add("p_price_max", maxPrice);
        dynamicParameters.Add("p_category", category);
        
        var products = _connection.QueryAsync<Product>("FilterProducts", dynamicParameters, commandType: CommandType.StoredProcedure);

        return products;
    }

    public Product UpdateProduct(int id, Product product)
    {
        _connection.ExecuteAsync(
            "UPDATE [Product] SET [Name]=@Name, [Price]=@Price, [Category]=@Category WHERE [Id]=@Id", new
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                Id = id
            });
        product.Id = id;
        
        return product;
    }

    public void DeleteProduct(int id)
    {
        _connection.ExecuteAsync("DELETE FROM [Product] WHERE [Id]=@Id", new
        {
            Id = id
        });
    }
}