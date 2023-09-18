using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.Exceptions;
using ClickCart.Service.Interfaces;

namespace ClickCart.Service.Services
{
    public class MerchantService : IMerchantService
    {
        private long _id;
        Repository<Merchant> MerchantRepository = new Repository<Merchant>();

        public async Task<MerchantForResultDto> CreateAsync(MerchantForCreationDto dto)
        {
            await GenerateIdAsync();
            var merchant1 = (await MerchantRepository.SelectAllAsync()).FirstOrDefault(e => e.FirstName == dto.FirstName && e.LastName == dto.LastName);
            if (merchant1 != null)
            {
                throw new ClickCartException(409, "This Merchant exists");

            }

            Merchant merchant = new Merchant()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MerchantDecription = dto.MerchantDecription,
                Role = dto.Role,
                MerchantRating = dto.MerchantRating,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await MerchantRepository.InsertAsync(merchant);

            MerchantForResultDto mfrd = new MerchantForResultDto()
            {
                Id = _id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MerchantDecription = dto.MerchantDecription,
                Role = dto.Role,
                MerchantRating = dto.MerchantRating,
                PhoneNumber = dto.PhoneNumber,
            };
            return mfrd;
        }

        public async Task<List<MerchantForResultDto>> GetAllAsync()
        {
            List<MerchantForResultDto> MerchantForResultDtos = new List<MerchantForResultDto>();
            var data = await MerchantRepository.SelectAllAsync();
            foreach (var dto in data)
            {
                MerchantForResultDto UpdatedData = new MerchantForResultDto()
                {
                    Id = dto.Id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    MerchantDecription = dto.MerchantDecription,
                    Role = dto.Role,
                    MerchantRating = dto.MerchantRating,
                    PhoneNumber = dto.PhoneNumber,
                };
                MerchantForResultDtos.Add(UpdatedData);
            }
            return MerchantForResultDtos;
        }

        public async Task<MerchantForResultDto> GetByIdAsync(long id)
        {
            var dto = await MerchantRepository.SelectByIdAsync(id);
            if (dto == null)
            {
                throw new ClickCartException(404, "Not Found");
            }
            var mfrd = new MerchantForResultDto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MerchantDecription = dto.MerchantDecription,
                Role = dto.Role,
                MerchantRating = dto.MerchantRating,
                PhoneNumber = dto.PhoneNumber,
            };
            return mfrd;
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var check = await MerchantRepository.SelectByIdAsync(id);
            if (check == null)
            {
                throw new ClickCartException(404, "Not Found");
            }
            else
            {
                var result = await MerchantRepository.DeleteAsync(id);
                return result;
            }
        }

        public async Task<MerchantForResultDto> UpdateAsync(MerchantForUpdateDto dto)
        {
            var check = await MerchantRepository.SelectByIdAsync(dto.Id);
            if (check == null)
            {
                throw new ClickCartException(404, "Not Found");
            }
            var MerchantForUpdate = new Merchant()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MerchantDecription = dto.MerchantDecription,
                Role = dto.Role,
                MerchantRating = dto.MerchantRating,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = check.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
            };
            await MerchantRepository.UpdateAsync(MerchantForUpdate);
            MerchantForResultDto result = new MerchantForResultDto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MerchantDecription = dto.MerchantDecription,
                Role = dto.Role,
                MerchantRating = dto.MerchantRating,
                PhoneNumber = dto.PhoneNumber,
            };

            return result;
        }

        public async Task GenerateIdAsync()
        {
            var res = await MerchantRepository.SelectAllAsync();
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
}
