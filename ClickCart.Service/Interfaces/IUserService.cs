using ClickCart.Service.DTOs.User;

namespace ClickCart.Service.Interfaces;

public interface IUserService
{
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync (long id);
    public Task<List<UserForResultDto>> GetAllAsync();
}
