using Microsoft.AspNetCore.Mvc;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Services;

namespace MyBurger.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController(ProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        return Ok(await productService.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ProductDTO productDTO, CancellationToken cancellationToken = default)
    {
        await productService.CreateAsync(productDTO, cancellationToken);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await productService.GetById(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> GetProductsIngrediant([FromBody] Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await productService.GetProductsIngrediant(id, cancellationToken));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid id, CancellationToken cancellationToken = default)
    {
        await productService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}
