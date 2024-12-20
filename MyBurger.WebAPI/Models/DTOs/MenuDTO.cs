namespace MyBurger.WebAPI.Models.DTOs;

public record MenuDTO(
    string Name,
    string Description,
    double Price,
    List<Guid> ProductIds,
    IFormFile MenuPic
    );
