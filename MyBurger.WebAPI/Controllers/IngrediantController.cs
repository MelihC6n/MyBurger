using Microsoft.AspNetCore.Mvc;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Services;

namespace MyBurger.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class IngrediantController(IngrediantService ingrediantService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        return Ok(await ingrediantService.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] IngrediantDTO ingrediantDTO, CancellationToken cancellationToken = default)
    {
        await ingrediantService.CreateAsync(ingrediantDTO, cancellationToken);
        return Created();
    }
}
