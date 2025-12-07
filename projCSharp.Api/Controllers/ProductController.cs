using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projCSharp.Application.DTOs;
using projCSharp.Application.Interfaces;

namespace projCSharp.Api.Controllers;

//[Authorize]
[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    // ------------------------------------------------------
    
    
    // GET BY ID:
    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = $"Producto con ID {id} no encontrado." });

        return Ok(product);
    }
    
    
    // GET ALL:
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }
    
    
    // CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        
    }

}