using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Repositories;
using System.Transactions;

namespace MyBurger.WebAPI.Services;

public class MenuService(MenuRepository menuRepository, BR_Menu_ProductRepository bR_Menu_ProductRepository, BR_Product_IngrediantRepository bR_Product_IngrediantRepository, IngrediantRepository ingrediantRepository, ProductRepository productRepository)
{
    public async Task<List<Menu>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await menuRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(MenuDTO menuDTO, CancellationToken cancellationToken = default)
    {
        string fileName = string.Join(".", DateTime.Now.ToFileTime().ToString(), menuDTO.MenuPic.FileName);
        Menu menu = new()
        {
            Name = menuDTO.Name,
            Description = menuDTO.Description,
            Price = menuDTO.Price,
            ImageUrl = fileName
        };

        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                await menuRepository.CreateAsync(menu, cancellationToken);

                foreach (var item in menuDTO.ProductIds)
                {
                    BR_Menu_Product bR_Menu_Product = new()
                    {
                        MenuId = menu.Id,
                        ProductId = item
                    };
                    await bR_Menu_ProductRepository.CreateAsync(bR_Menu_Product, cancellationToken);
                }

                transaction.Complete();
                using (var stream = System.IO.File.Create($"wwwroot/menuImages/{fileName}"))
                {
                    menuDTO.MenuPic.CopyTo(stream);
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public async Task<List<ProductWithIngrediantDTO>> GetMenuProductsIngrediant(Guid id, CancellationToken cancellationToken = default)
    {
        List<ProductWithIngrediantDTO> returnList = new List<ProductWithIngrediantDTO>();

        var bridgeList = await bR_Menu_ProductRepository.GetAllAsync(cancellationToken);
        var filteredBridgeList = bridgeList.Where(br => br.MenuId == id).ToList();
        var proIngBridgeList = await bR_Product_IngrediantRepository.GetAllAsync(cancellationToken);
        var ingrediantList = await ingrediantRepository.GetAllAsync(cancellationToken);

        foreach (var item in filteredBridgeList)
        {
            var filteredIdList = proIngBridgeList.Where(br => br.ProductId == item.ProductId);
            var productsIngrediantsList = ingrediantList.Where(ing => filteredIdList.Any(fil => fil.IngrediantId == ing.Id)).ToList();
            var resultIngrediantDto = productsIngrediantsList.Select(ingrediant => new IngrediantDTO(ingrediant.Id, ingrediant.Name, ingrediant.Description)).ToList();
            var productDetails = await productRepository.GetByIdAsync(item.ProductId, cancellationToken);
            ProductWithIngrediantDTO productDTO = new(productDetails.Id, productDetails.Name, productDetails.Price, resultIngrediantDto);
            returnList.Add(productDTO);
        }

        return returnList;
    }

    public async Task UpdateAsync(Guid id, string name, string description, double price, string imageUrl, CancellationToken cancellationToken = default)
    {
        Menu? menu = await menuRepository.GetByIdAsync(id, cancellationToken);
        if (menu is null)
        {
            throw new ArgumentException("Data is not found");
        }
        menu.Name = name;
        menu.Description = description;
        menu.Price = price;
        menu.ImageUrl = imageUrl;
        await menuRepository.UpdateAsync(menu, cancellationToken);
    }

    public async Task DeleteById(Guid id, CancellationToken cancellationToken = default)
    {
        var bridgeList = await bR_Menu_ProductRepository.GetAllAsync(cancellationToken);
        var deleteBridgeList = bridgeList.Where(br => br.MenuId == id).ToList();
        await bR_Menu_ProductRepository.DeleteAsync(deleteBridgeList, cancellationToken);

        Menu? menu = await menuRepository.GetByIdAsync(id, cancellationToken);
        if (menu is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await menuRepository.DeleteAsync(menu, cancellationToken);
    }
}
