namespace projCSharp.Domain.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Categorie>> GetAllAsync();
    Task<Categorie> GetByIdAsync(int id);
    Task<Categorie> CreateAsync(Categorie categorie);
    Task<Categorie> UpdateAsync(Categorie categorie);
    Task<bool> DeleteAsync(int id);
}