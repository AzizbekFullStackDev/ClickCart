using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;

namespace ClickCart.Service.Interfaces
{
    public interface IUserAuthentication
    {
        public Task<AuthResult> AuthoriseAsync(Authentification auth);
    }
}
