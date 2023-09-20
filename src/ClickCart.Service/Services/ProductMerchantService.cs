using ClickCart.Data.Repositories;
using ClickCart.Domain.Configurations;
using ClickCart.Domain.Entities;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.DTOs.Product;
using ClickCart.Service.Interfaces;
using System.IO;

namespace ClickCart.Service.Services;

public class ProductMerchantService : IProductMerchantConnection
{
    public readonly string PathDB = DatabasePath.ProductMerchantConnectionDb;
    public async Task<List<ProductMerchentConnection>> GetAllProductsWithMerchantsInfoAsync()
    {
        MerchantService merchantService = new MerchantService();
        ProductService productService = new ProductService();

        var merchants = await merchantService.GetAllAsync();
        var products = await productService.GetAllAsync();
        Repository<ProductMerchentConnection> repository = new Repository<ProductMerchentConnection>();
        if (merchants == null || products == null)
        {
            Console.WriteLine("Merchant or product data is null.");
            return null;
        }

        var groupedProducts = products.GroupBy(
            product => product.MerchantId,
            (MerchantId, sellerProducts) => new
            {
                MerchantId = MerchantId,
                Products = sellerProducts.ToList()
            });

        var result = from merchantGroup in groupedProducts
                     join mer in merchants on merchantGroup.MerchantId equals mer.Id
                     from product in merchantGroup.Products
                     select new ProductMerchentConnection
                     {
                         Id = product.Id,
                         CreatedAt = DateTime.UtcNow,
                         MerchantId = mer.Id,
                         MerchantName = mer.FirstName,
                         ProductBrand = product.Brand,
                         ProductName = product.Name,
                         ProductDescription = product.Description,
                         ProductPrice = product.Price,
                         ProductCategory = product.Category,
                         ProductId = product.Id,
                         ProductStockQuantity = product.StockQuantity,
                         UpdatedAt = DateTime.UtcNow,
                     };

        await File.WriteAllTextAsync(PathDB, "[]");
        foreach( var item in result )
        {
            await repository.InsertAsync( item );
        }

        return result.ToList();
    }


}
