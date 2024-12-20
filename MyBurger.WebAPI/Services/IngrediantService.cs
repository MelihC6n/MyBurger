using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Repositories;

namespace MyBurger.WebAPI.Services;

public class IngrediantService(IngrediantRepository ingrediantRepository)
{
    public async Task<List<Ingrediant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await ingrediantRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(IngrediantDTO ingrediantDTO, CancellationToken cancellationToken = default)
    {
        Ingrediant ingrediant = new()
        {
            Name = ingrediantDTO.Name,
            Description = ingrediantDTO.Description,
        };
        await ingrediantRepository.CreateAsync(ingrediant, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, string name, string description, CancellationToken cancellationToken = default)
    {
        Ingrediant? ingrediant = await ingrediantRepository.GetByIdAsync(id, cancellationToken);
        if (ingrediant is null)
        {
            throw new ArgumentException("Data is not found.");
        }
        ingrediant.Name = name;
        ingrediant.Description = description;
        await ingrediantRepository.UpdateAsync(ingrediant, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Ingrediant? ingrediant = await ingrediantRepository.GetByIdAsync(id, cancellationToken);
        if (ingrediant is null)
        {
            throw new ArgumentException("Data is not found.");
        }
        await ingrediantRepository.DeleteAsync(ingrediant, cancellationToken);
    }
}