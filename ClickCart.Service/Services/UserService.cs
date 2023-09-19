using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Service.DTOs.User;
using ClickCart.Service.Exceptions;
using ClickCart.Service.Interfaces;

namespace ClickCart.Service.Services;

public class UserService : IUserService
{
    private long _id;
    Repository<User> UserRepository = new Repository<User>();
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        await GenerateIdAsync();
        var user1 = (await UserRepository.SelectAllAsync()).FirstOrDefault(e => e.FirstName == dto.FirstName && e.LastName == dto.LastName);
        if (user1 != null)
        {
            throw new ClickCartException(409, "This User exists");

        }

        User user = new User()
        {
            Id = _id,
            EmailAddress = dto.EmailAddress,
            Password = dto.Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            DateOfBirth = dto.DateOfBirth,
            Balance = dto.Balance,
            PaymentInformation = dto.PaymentInformation,
            City = dto.City,
            Country = dto.Country,
            StreetAddress = dto.StreetAddress,
            ZipPostalCode = dto.ZipPostalCode,
            UserRole = Domain.Enums.Roles.Customer,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        await UserRepository.InsertAsync(user);

        UserForResultDto ufrd = new UserForResultDto()
        {
            Id = _id,
            FirstName = dto.FirstName,
            EmailAddress = dto.EmailAddress,
            LastName = dto.LastName,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            DateOfBirth = dto.DateOfBirth,
            Balance = dto.Balance,
            PaymentInformation = dto.PaymentInformation,
            City = dto.City,
            Country = dto.Country,
            StreetAddress = dto.StreetAddress,
            ZipPostalCode = dto.ZipPostalCode,
            Password = dto.Password,

        };
        return ufrd;
    }

    public async Task<List<UserForResultDto>> GetAllAsync()
    {
        List<UserForResultDto> userForResultDtos = new List<UserForResultDto>();
        var data = await UserRepository.SelectAllAsync();
        foreach (var dto in data)
        {
            UserForResultDto UpdatedData = new UserForResultDto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                EmailAddress = dto.EmailAddress,
                LastName = dto.LastName,
                Username = dto.Username,
                PhoneNumber = dto.PhoneNumber,
                DateOfBirth = dto.DateOfBirth,
                Balance = dto.Balance,
                PaymentInformation = dto.PaymentInformation,
                City = dto.City,
                Country = dto.Country,
                StreetAddress = dto.StreetAddress,
                ZipPostalCode = dto.ZipPostalCode,
                Password = dto.Password,

            };
            userForResultDtos.Add(UpdatedData);
        }
        return userForResultDtos;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var dto = await UserRepository.SelectByIdAsync(id);
        if(dto == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        var ufrd = new UserForResultDto()
        {
            Id = id,
            FirstName = dto.FirstName,
            EmailAddress = dto.EmailAddress,
            LastName = dto.LastName,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            DateOfBirth = dto.DateOfBirth,
            Balance = dto.Balance,
            PaymentInformation = dto.PaymentInformation,
            City = dto.City,
            Country = dto.Country,
            StreetAddress = dto.StreetAddress,
            ZipPostalCode = dto.ZipPostalCode,
            Password = dto.Password,
        };
        return ufrd;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var check = await UserRepository.SelectByIdAsync(id);
        if(check == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        else
        {
            var result = await UserRepository.DeleteAsync(id);
            return result;
        }
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var check = await UserRepository.SelectByIdAsync(dto.Id);
        if(check == null)
        {
            throw new ClickCartException(404, "Not Found");
        }
        var UserForUpdate = new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            EmailAddress = dto.EmailAddress,
            LastName = dto.LastName,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            DateOfBirth = check.DateOfBirth,
            Balance = dto.Balance,
            Password = check.Password,
            PaymentInformation = dto.PaymentInformation,
            City = dto.City,
            Country = dto.Country,
            StreetAddress = dto.StreetAddress,
            ZipPostalCode = dto.ZipPostalCode,
            UserRole = Domain.Enums.Roles.Customer,
            UpdatedAt = DateTime.UtcNow,
            CreatedAt = check.CreatedAt,
        };
        await UserRepository.UpdateAsync(UserForUpdate);
        UserForResultDto result = new UserForResultDto()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            EmailAddress = dto.EmailAddress,
            LastName = dto.LastName,
            Username = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            DateOfBirth = dto.DateOfBirth,
            Balance = dto.Balance,
            PaymentInformation = dto.PaymentInformation,
            City = dto.City,
            Country = dto.Country,
            StreetAddress = dto.StreetAddress,
            ZipPostalCode = dto.ZipPostalCode,
            Password = dto.Password,

        };

        return result;

    }

    public async Task GenerateIdAsync()
    {
        var res = await UserRepository.SelectAllAsync(); 
        if(res.Count == 0)
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
