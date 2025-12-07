using Microsoft.EntityFrameworkCore;
using projCSharp.Domain;
using projCSharp.Domain.Interfaces.Repositories;
using projCSharp.Infrastructure.Data;

namespace projCSharp.Infrastructure.Repositories;

public class CategorieRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategorieRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ---------------------------------------------

    // GET ALL:
    public async Task<IEnumerable<Categorie>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    
    // GET BY ID:
    public async Task<Categorie> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    
    // CREATE:
    public async Task<Categorie> CreateAsync(Categorie categorie)
    {
        _context.Categories.Add(categorie);
        await _context.SaveChangesAsync();
        return categorie;
    }

    
    // UPDATE:
    public async Task<Categorie> UpdateAsync(Categorie categorie)
    {
        var exists = await _context.Categories.FindAsync(categorie.Id);

        if (exists == null)
            return null;

        exists.Name = categorie.Name;

        await _context.SaveChangesAsync();
        return categorie;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.Categories.FindAsync(id);

        if (toDelete == null)
            return false;

        _context.Categories.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}