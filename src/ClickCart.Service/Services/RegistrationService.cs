using ClickCart.Domain.Entities;
using ClickCart.Service.Interfaces;

namespace ClickCart.Service.Services
{
    public class RegistrationService : IRegistrationService
    {
        public async Task<Registration> SignUpAsync(Registration register)
        {
            Registration registration = new Registration()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                EmailAddress = register.EmailAddress,
                Password = register.Password,
                PhoneNumber = register.PhoneNumber,
                CreatedAt = DateTime.UtcNow,
            };
            return registration;
        }


    }
}
