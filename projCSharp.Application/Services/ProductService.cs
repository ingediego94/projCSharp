using System.Net.Http.Headers;
using projCSharp.Application.Interfaces;
using projCSharp.Domain;
using projCSharp.Domain.Interfaces.Repositories;

namespace projCSharp.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    // -------------------------------------------------
    
    // GET ALL:
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    
    // GET BY ID:
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    
    // CREATE:
    public async Task<Product> CreateAsync(Product product)
    {
        return await _productRepository.CreateAsync(product);
    }
    
    
    // UPDATE:
    public async Task<bool> UpdateAsync(Product product)
    {
        var exists = await _productRepository.GetByIdAsync(product.Id);

        if (exists == null)
            return false;

        await _productRepository.UpdateAsync(product);
        return true;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _productRepository.GetByIdAsync(id);

        if (toDelete == null)
            return false;

        await _productRepository.DeleteAsync(id);
        return true;
    }
}