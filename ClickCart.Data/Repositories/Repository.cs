using ClickCart.Data.IRepositories;
using ClickCart.Domain.Commons;
using ClickCart.Domain.Configurations;
using ClickCart.Domain.Entities;
using Newtonsoft.Json;

namespace ClickCart.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public readonly string PathDB;

    public Repository()
    {
        if(typeof(TEntity) == typeof(CartItem))
        {
            this.PathDB = DatabasePath.CartItemDb;
        }
        else if (typeof(TEntity) == typeof(Category))
        {
            this.PathDB = DatabasePath.CategoryDb;
        }
        else if (typeof(TEntity) == typeof(Merchant))
        {
            this.PathDB = DatabasePath.MerchantDb;
        }
        else if (typeof(TEntity) == typeof(Orders))
        {
            this.PathDB = DatabasePath.OrdersDb;
        }
        else if (typeof(TEntity) == typeof(PaymentTransaction))
        {
            this.PathDB = DatabasePath.PaymentTransactionDb;
        }
        else if (typeof(TEntity) == typeof(Product))
        {
            this.PathDB = DatabasePath.ProductDb;
        }
        else if (typeof(TEntity) == typeof(Registration))
        {
            this.PathDB = DatabasePath.RegistrationDb;
        }
        else if (typeof(TEntity) == typeof(User))
        {
            this.PathDB = DatabasePath.UserDb;
        }
        else if (typeof(TEntity) == typeof(ProductMerchentConnection))
        {
            this.PathDB = DatabasePath.ProductMerchantConnectionDb;
        }

        var str = File.ReadAllText(PathDB);
        if (string.IsNullOrEmpty(str))
        {
           File.WriteAllText(PathDB, "[]");
        }
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var str = await SelectAllAsync();
        var DataToRemove = str.FirstOrDefault(e => e.Id == id);
        str.Remove(DataToRemove);
        var result = JsonConvert.SerializeObject(str, Formatting.Indented);
        await File.WriteAllTextAsync(PathDB, result);
        return true;
    }

    public async Task<List<TEntity>> SelectAllAsync()
    {
        var data = await File.ReadAllTextAsync(PathDB);
        var json = JsonConvert.DeserializeObject<List<TEntity>>(data);
        return json;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        string AllData = await File.ReadAllTextAsync(PathDB);
        var json = JsonConvert.DeserializeObject<List<TEntity>>(AllData);
        json.Add(entity);
        var result = JsonConvert.SerializeObject(json, Formatting.Indented);
        await File.WriteAllTextAsync(PathDB, result);
        return entity;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var data = (await SelectAllAsync()).FirstOrDefault(e => e.Id == id);
        return data;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var data = await SelectAllAsync();
        await File.WriteAllTextAsync(PathDB, "[]");
        foreach (var item in data)
        {
            if(item.Id == entity.Id)
            {
                await InsertAsync(entity);
                continue;
            }
                await InsertAsync(item);
        }
        return entity;

    }
}
