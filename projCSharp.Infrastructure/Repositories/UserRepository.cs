using Microsoft.EntityFrameworkCore;
using projCSharp.Domain;
using projCSharp.Domain.Interfaces.Repositories;
using projCSharp.Infrastructure.Data;

namespace projCSharp.Infrastructure.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ------------------------------------------------------

    // GET BY ID:
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    
    // GET ALL:
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
    
    
    // CREATE:
    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    
    // UPDATE:
    public async Task<User> UpdateAsync(User user)
    {
        // var exists = await _context.Users.FindAsync(user.Id);
        //
        // if (exists == null)
        //     return null;
        //
        // exists.Email = user.Email;
        // exists.Name = user.Name;
        // exists.LastName = user.LastName;
        // exists.NumDoc = user.NumDoc;
        // exists.PasswordHash = exists.PasswordHash;
        // exists.Role = user.Role;
        
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}