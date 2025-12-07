namespace projCSharp.Application.DTOs;

// CREATE:
public class ProductCreateDto
{
    public string Name { get; set; } = string.Empty;
    public int CategorieId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

// CREATE RESPONSE:
public class ProductCreateResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategorieId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}