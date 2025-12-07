namespace projCSharp.Domain;

public class Categorie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Inverse relation:
    public ICollection<Product> Products { get; set; } = new List<Product>();
}