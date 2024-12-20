namespace MyBurger.WebAPI.Models.DTOs;

public record IngrediantDTO(
    Guid? Id,
    string Name,
    string Description
    );