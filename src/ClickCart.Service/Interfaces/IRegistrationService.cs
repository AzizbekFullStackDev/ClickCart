using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;

namespace ClickCart.Service.Interfaces;

public interface IRegistrationService
{
    public Task<Registration> SignUpAsync(Registration register);
}
