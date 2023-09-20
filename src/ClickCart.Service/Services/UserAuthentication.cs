using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Service.Interfaces;

namespace ClickCart.Service.Services
{
    public class UserAuthentication : IUserAuthentication
    {
        public async Task<AuthResult> AuthoriseAsync(Authentification auth)
        {
            var userService = new Repository<User>();
            var merchantService = new Repository<Merchant>();

            var users = await userService.SelectAllAsync();
            var merchants = await merchantService.SelectAllAsync();

            // Check if the authentication data matches a user
            var user = users.FirstOrDefault(u => u.EmailAddress == auth.EmailAddress && u.Password == auth.Password);
            if (user != null && user.UserRole == Roles.Customer)
            {
                return AuthResult.UserAuthenticated;
            }

            // Check if the authentication data matches a merchant
            var merchant = merchants.FirstOrDefault(m => m.EmailAddress == auth.EmailAddress && m.Password == auth.Password);
            if (merchant != null && merchant.Role == Roles.Merchant)
            {
                return AuthResult.MerchantAuthenticated;
            }
            if(auth.EmailAddress == "admin" && auth.Password == "admin")
            {
                return AuthResult.SuperAdmin;
            }

            // Authentication failed
            return AuthResult.AuthenticationFailed;
        }

       
    }
}
