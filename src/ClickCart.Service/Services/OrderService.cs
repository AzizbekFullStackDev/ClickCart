using ClickCart.Data.IRepositories;
using ClickCart.Data.Repositories;
using ClickCart.Domain.Configurations;
using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Service.Exceptions;
using ClickCart.Service.Interfaces;
using System.IO;
using System.Security.Cryptography;

namespace ClickCart.Service.Services;

public class OrderService : IOrdersService
{
    private long _id;
    public readonly string PathDB = DatabasePath.OrdersDb;
    Repository<Orders> OrderRepository = new Repository<Orders>();
    public async Task<List<Orders>> PurchaseProductAsync(long userId, long Id, Orders order)
    {
        await GenerateIdAsync();
        List<Orders> orders = new List<Orders>();

        var ProductService = new ProductService();

        var UserService = new UserService();
        
        var product = await ProductService.GetByIdAsync(Id);
        
        var user = await UserService.GetByIdAsync(userId);
        
        if(product == null)
        {
            throw new ClickCartException(404, "notFound");
        }
        var result = new Orders()
        {
            Id = _id,
            UserId = userId,
            ProductId = Id,
            ProductName = product.Name,
            CreatedAt = DateTime.UtcNow,
            OrderStatus = "Processing",
            PaymentMethod = user.PaymentInformation,
            ProductQuantity = order.ProductQuantity,
            Country = user.Country,
            City = user.City,
            street = user.StreetAddress,
            ZipCode = user.ZipPostalCode,
            TotalAmount  = order.TotalAmount,
            
        };
        orders.Add(result);

        //await File.WriteAllTextAsync(PathDB, "[]");
        foreach (var item in orders)
        {
            await OrderRepository.InsertAsync(item);
        }


        return orders;


    }
    public Task<List<Orders>> GetAllOrdersAsync()
    {
        var result = OrderRepository.SelectAllAsync();
        return result;
    }
    public async Task GenerateIdAsync()
        {
            var res = await OrderRepository.SelectAllAsync();
            if (res.Count == 0)
            {
                _id = 1;
            }
            else
            {
                var r = res[res.Count - 1];
                _id = ++r.Id;
            }
        }

    
}
