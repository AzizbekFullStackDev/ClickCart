using ClickCart.Data.Repositories;
using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Presentation.UI;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.DTOs.Product;
using ClickCart.Service.DTOs.User;
using ClickCart.Service.Services;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace ClickCart.Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            await ui.RunCodeAsync();



        }
    }
}