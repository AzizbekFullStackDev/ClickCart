using ClickCart.Domain.Entities;

namespace ClickCart.Service.Interfaces
{
    public interface IOrdersService
    {
        public Task<List<Orders>> PurchaseProductAsync(long userId,long Id, Orders order);

    }
}
