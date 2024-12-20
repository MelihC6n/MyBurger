namespace MyBurger.WebAPI.Models.DTOs;

public record ProductWithIngrediantDTO(
    Guid ProductId,
    string ProductName,
    double ProductPrice,
    List<IngrediantDTO> IngrediantDTOs
    );
