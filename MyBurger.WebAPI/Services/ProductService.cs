using MyBurger.WebAPI.Models;
using MyBurger.WebAPI.Models.DTOs;
using MyBurger.WebAPI.Repositories;
using System.Transactions;

namespace MyBurger.WebAPI.Services;

public class ProductService(ProductRepository productRepository, BR_Product_IngrediantRepository bR_Product_IngrediantRepository, IngrediantRepository ingrediantRepository)
{
    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await productRepository.GetAllAsync(cancellationToken);
    }

    public async Task<List<IngrediantDTO>> GetProductsIngrediant(Guid productId, CancellationToken cancellationToken = default)
    {
        var bridgeList = await bR_Product_IngrediantRepository.GetAllAsync(cancellationToken);
        var filteredIdList = bridgeList.Where(br => br.ProductId == productId);
        var ingrediantList = await ingrediantRepository.GetAllAsync(cancellationToken);
        var productsIngrediantsList = ingrediantList.Where(ing => filteredIdList.Any(fil => fil.IngrediantId == ing.Id)).ToList();
        return productsIngrediantsList.Select(ingrediant => new IngrediantDTO(ingrediant.Id, ingrediant.Name, ingrediant.Description)).ToList();
    }

    public async Task CreateAsync(ProductDTO productDTO, CancellationToken cancellationToken = default)
    {
        string fileName = string.Join(".", DateTime.Now.ToFileTime().ToString(), productDTO.ProductPic.FileName);

        Product product = new()
        {
            Name = productDTO.Name,
            Description = productDTO.Description,
            Price = productDTO.Price,
            ImageUrl = fileName,
        };

        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                await productRepository.CreateAsync(product, cancellationToken);

                if (productDTO.IngrediantsId != null)
                    foreach (var item in productDTO.IngrediantsId)
                    {
                        BR_Product_Ingrediant bR_Product_Ingrediant = new()
                        {
                            IngrediantId = item,
                            ProductId = product.Id
                        };
                        await bR_Product_IngrediantRepository.CreateAsync(bR_Product_Ingrediant, cancellationToken);
                    };

                transaction.Complete();
                using (var stream = System.IO.File.Create($"wwwroot/productImages/{fileName}"))
                {
                    productDTO.ProductPic.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public async Task UpdateAsync(Guid id, string name, string description, double price, string imageUrl, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("Data is not found");
        }
        product.Name = name;
        product.Description = description;
        product.Price = price;
        product.ImageUrl = imageUrl;
        await productRepository.UpdateAsync(product);

    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var bridgeList = await bR_Product_IngrediantRepository.GetAllAsync(cancellationToken);
        var deleteBridgeList = bridgeList.Where(br => br.ProductId == id).ToList();
        await bR_Product_IngrediantRepository.DeleteAsync(deleteBridgeList, cancellationToken);

        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("Data is not found");
        }
        await productRepository.DeleteAsync(product, cancellationToken);
    }

    public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        Product? product = await productRepository.GetByIdAsync(id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("Data is not found");
        }
        return product;
    }
}
