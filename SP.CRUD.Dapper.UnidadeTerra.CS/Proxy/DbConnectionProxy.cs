using System.Data.SqlClient;

namespace SP.CRUD.Dapper.UnidadeTerra.CS.Proxy;

public class DbConnectionProxy
{
    private IConfiguration _configuration;

    public DbConnectionProxy(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("ShopDbConnectionString"));
    }
}