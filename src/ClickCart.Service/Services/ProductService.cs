using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Service.DTOs.Product;
using ClickCart.Service.Exceptions;
using ClickCart.Service.Interfaces;

namespace ClickCart.Service.Services;

public class ProductService : IProductService
{
    private long _id;
    Repository<Product> repository = new Repository<Product>();
    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        await GenerateIdAsync();
        var check = (await repository.SelectAllAsync()).FirstOrDefault(e => e.Name == dto.Name && e.MerchantId == dto.MerchantId);
        if(check != null) 
        {
            throw new ClickCartException(409, "This Product exists in Database");
        };
        Product product = new Product()
        {
            Id = _id,
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            Description = dto.Description,
            Price = dto.Price,
            MerchantId = dto.MerchantId,
            StockQuantity = dto.StockQuantity,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            
        };

        await repository.InsertAsync(product);

        ProductForResultDto Result = new ProductForResultDto()
        {
            Id = _id,
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            Description = dto.Description,
            Price = dto.Price,
            MerchantId = dto.MerchantId,
            StockQuantity = dto.StockQuantity,
        };
        return Result;
    }

    public async Task<List<ProductForResultDto>> GetAllAsync()
    {
        var result = await repository.SelectAllAsync();
        List<ProductForResultDto> ls = new List<ProductForResultDto>();
        foreach (var item in result)
        {
            var res = new ProductForResultDto()
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Category = item.Category,
                Description= item.Description,
                Price = item.Price,
                MerchantId = item.MerchantId,
                StockQuantity = item.StockQuantity,
            };
            ls.Add(res);
        }
        return ls;
    }

    public async Task<ProductForResultDto> GetByIdAsync(long id)
    {
        var check = await repository.SelectByIdAsync(id);
        if(check == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        var Getdata = await repository.SelectByIdAsync(id);
        var result = new ProductForResultDto()
        {
            Id = Getdata.Id,
            Name = Getdata.Name,
            Brand = Getdata.Brand,
            Category = Getdata.Category,
            Description = Getdata.Description,
            Price = Getdata.Price,
            MerchantId = Getdata.MerchantId,
            StockQuantity = Getdata.StockQuantity,
        };
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var check = await repository.SelectByIdAsync(id);
        if(check == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        var result = await repository.DeleteAsync(id);
        return result;
    }

    public async Task<ProductForUpdateDto> UpdateAsync(ProductForUpdateDto dto)
    {
        var check = await repository.SelectByIdAsync(dto.Id);
        if (check == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        var product = new Product()
        {
            Id = check.Id,
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            Description = dto.Description,
            Price = dto.Price,
            MerchantId = dto.MerchantId,
            StockQuantity = dto.StockQuantity,
            CreatedAt = check.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
        };
        await repository.UpdateAsync(product);
        var ProductResult = new ProductForUpdateDto()
        {
            Id = check.Id,
            Name = dto.Name,
            Brand = dto.Brand,
            Category = dto.Category,
            Description = dto.Description,
            Price = dto.Price,
            MerchantId = dto.MerchantId,
            StockQuantity = dto.StockQuantity,
        };
        return ProductResult;
    }

    public async Task GenerateIdAsync()
    {
        var all = await repository.SelectAllAsync();
        if(all.Count == 0)
        {
            _id = 1;
        }
        else
        {
            var s = all[all.Count - 1];
            _id = ++s.Id;
        }
    }

}
