using ClickCart.Domain.Entities;

namespace ClickCart.Service.Interfaces;

public interface IProductMerchantConnection
{
    public Task<List<ProductMerchentConnection>> GetAllProductsWithMerchantsInfoAsync();
}
