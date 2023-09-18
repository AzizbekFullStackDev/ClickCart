using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Service.DTOs.Product;

namespace ClickCart.Service.Interfaces
{
    public interface IProductService
    {
        public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
        public Task<ProductForUpdateDto> UpdateAsync(ProductForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<ProductForResultDto> GetByIdAsync(long id);
        public Task<List<ProductForResultDto>> GetAllAsync();
    }
}
