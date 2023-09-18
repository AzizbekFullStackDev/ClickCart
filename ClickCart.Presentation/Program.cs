using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Presentation.UI;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.DTOs.Product;
using ClickCart.Service.DTOs.User;
using ClickCart.Service.Services;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace ClickCart.Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            //await ui.RunCodeAsync();
            //UserService userService = new UserService();
            MerchantService MerchantService = new MerchantService();
            //Repository<User> repository = new Repository<User>();
            ProductService ProductService = new ProductService();

            var merchants = await MerchantService.GetAllAsync();
            var products = await ProductService.GetAllAsync();

            var orderService = new OrderService();

            var OrderResult = new Orders()
            {
                UserId = 1, // Set UserId to 1
                ProductId = 4,
                CreatedAt = DateTime.UtcNow,
                OrderStatus = "Processing",
                ProductQuantity = 2,
                TotalAmount = 500,
            };

            await orderService.PurchaseProductAsync(1, 4, OrderResult);

            //ProductMerchantService Get All for Console Ui
            /*ProductMerchantService productMerchantService = new ProductMerchantService();
             var result2 = await productMerchantService.GetAllProductsWithMerchantsInfoAsync();

             foreach (var item in result2)
             {
                 Console.WriteLine("________");
                 Console.WriteLine($"Product Id: {item.Id}");
                 Console.WriteLine($"MerchantId: {item.MerchantId}");
                 Console.WriteLine($"MerchantName: {item.MerchantName}");
                 Console.WriteLine($"ProductName: {item.ProductName}");
                 Console.WriteLine($"ProductBrand: {item.ProductBrand}");
                 Console.WriteLine($"ProductDescription: {item.ProductDescription}");
                 Console.WriteLine($"ProductId: {item.ProductId}");
                 Console.WriteLine($"ProductPrice: {item.ProductPrice}");
                 Console.WriteLine($"ProductCategory: {item.ProductCategory}");
                 Console.WriteLine($"ProductStockQuantity: {item.ProductStockQuantity}");
                 Console.WriteLine($"CreatedAt: {item.CreatedAt}");
             }*/

        }
    }
}