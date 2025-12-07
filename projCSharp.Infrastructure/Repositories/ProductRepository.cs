using Microsoft.EntityFrameworkCore;
using projCSharp.Domain;
using projCSharp.Domain.Interfaces.Repositories;
using projCSharp.Infrastructure.Data;

namespace projCSharp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    // --------------------------------------------
    
    // GET ALL:
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    
    // GET BY ID:
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    
    // CREATE:
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    
    // UPDATE:
    public async Task<Product?> UpdateAsync(Product product)
    {
        var exists = await _context.Products.FindAsync(product.Id);

        if (exists == null)
            return null;
        exists.Name = product.Name;
        exists.Price = product.Price;
        exists.Quantity = product.Quantity;
        
        await _context.SaveChangesAsync();
        return product;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.Products.FindAsync(id);
        
        if (toDelete == null)
            return false;
        
        _context.Products.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}