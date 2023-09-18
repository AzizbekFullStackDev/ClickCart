
using ClickCart.Service.DTOs.Merchant;

namespace ClickCart.Service.Interfaces
{
    public interface IMerchantService
    {
        public Task<MerchantForResultDto> CreateAsync(MerchantForCreationDto dto);
        public Task<MerchantForResultDto> UpdateAsync(MerchantForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<MerchantForResultDto> GetByIdAsync(long id);
        public Task<List<MerchantForResultDto>> GetAllAsync();
    }
}
