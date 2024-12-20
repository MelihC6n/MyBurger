namespace MyBurger.WebAPI.Models.DTOs;

public record ProductDTO(
    string Name,
    string Description,
    double Price,
    List<Guid>? IngrediantsId,
    IFormFile ProductPic
    );
