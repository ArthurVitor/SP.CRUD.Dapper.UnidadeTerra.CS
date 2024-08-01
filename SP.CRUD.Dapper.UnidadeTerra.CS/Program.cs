using SP.CRUD.Dapper.UnidadeTerra.CS.Profiles;
using SP.CRUD.Dapper.UnidadeTerra.CS.Proxy;
using SP.CRUD.Dapper.UnidadeTerra.CS.Repositories;
using SP.CRUD.Dapper.UnidadeTerra.CS.Repositories.Interfaces;
using SP.CRUD.Dapper.UnidadeTerra.CS.Services;
using SP.CRUD.Dapper.UnidadeTerra.CS.Services.Interface;

namespace SP.CRUD.Dapper.UnidadeTerra.CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // DbConnection
            builder.Services.AddSingleton<DbConnectionProxy>();
            
            // Mapper
            builder.Services.AddScoped<IMapper, Mapper>();
            
            // Product
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
