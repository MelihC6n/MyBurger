using Microsoft.AspNetCore.Mvc;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Services;

namespace MyBurger.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class MenuController(MenuService menuService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        return Ok(await menuService.GetAllAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] MenuDTO menuDTO, CancellationToken cancellationToken = default)
    {
        await menuService.CreateAsync(menuDTO, cancellationToken);
        return Created();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid id, CancellationToken cancellationToken = default)
    {
        await menuService.DeleteById(id, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> GetMenuProductsIngrediant([FromBody] Guid id, CancellationToken cancellationToken = default)
    {
        return Ok(await menuService.GetMenuProductsIngrediant(id));
    }
}