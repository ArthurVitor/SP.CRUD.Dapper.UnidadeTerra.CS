namespace SP.CRUD.Dapper.UnidadeTerra.CS.Dtos.ProductDto;

public class ListProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public double Price { get; set; }

    public string Category { get; set; } = string.Empty;
}