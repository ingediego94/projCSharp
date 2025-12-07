namespace projCSharp.Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategorieId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    
    // Relation 1:N
    public Categorie Categorie { get; set; }
}