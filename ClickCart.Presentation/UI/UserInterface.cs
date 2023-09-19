using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.DTOs.User;
using ClickCart.Service.Services;
using NAudio.Wave;

namespace ClickCart.Presentation.UI
{
    public class UserInterface
    {
        public async Task RunCodeAsync()
        {

            //  #region 

            string audioFilePath2 = "D:\\Net new Source Codes\\ClickCart\\ClickCart.Presentation\\UI\\sword.m4a"; // Replace with the actual path to your audio file

            // Check if the audio file exists
            if (!File.Exists(audioFilePath2))
            {
                Console.WriteLine("Audio file not found.");
                return;
            }

            using (var audioFile = new AudioFileReader(audioFilePath2))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += (sender, args) => OnAudioPlaybackStopped();
                outputDevice.Play();
                string prompt = @"
                       ____   _   _          _       ____                  _   
                      / ___| | | (_)   ___  | | __  / ___|   __ _   _ __  | |_ 
                     | |     | | | |  / __| | |/ / | |      / _` | | '__| | __|
                     | |___  | | | | | (__  |   <  | |___  | (_| | | |    | |_ 
                      \____| |_| |_|  \___| |_|\_\  \____|  \__,_| |_|     \__|
";

                // Save the current console text color
                ConsoleColor originalColor = Console.ForegroundColor;

                // Set the text color to dark blue
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                // Print the prompt
                Console.WriteLine(prompt);

                // Restore the original console text color
                Console.ForegroundColor = originalColor;
                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // You can add optional code here while waiting for the audio to finish
                }
            }

            string audioFilePath = "D:\\Net new Source Codes\\ClickCart\\ClickCart.Presentation\\UI\\intro.m4a"; // Replace with the actual path to your audio file

            // Check if the audio file exists
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file not found.");
                return;
            }

            using (var audioFile = new AudioFileReader(audioFilePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += (sender, args) => OnAudioPlaybackStopped();
                outputDevice.Play();

                // Wait for the audio to finish playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // You can add optional code here while waiting for the audio to finish
                }
            }



            //#endregion
            while (true)
            {
            Console.WriteLine("1 => Foydalanuvchi sifatida ro`yhatdan o`tish");
            Console.WriteLine("2 => Sotuvchi sifatida ro`yhatdan o`tish");
            Console.WriteLine("3 => Kirish");
            int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        var userService = new UserService();
                        var dto = new UserForCreationDto();
                        
                        Console.WriteLine("Ismingizni Kiriting");
                        dto.FirstName = Console.ReadLine();

                        Console.WriteLine("Familiyangizni Kiriting");
                        dto.LastName = Console.ReadLine();

                        Console.WriteLine("Username Kiriting");
                        dto.Username = Console.ReadLine();

                        Console.WriteLine("Elektron pochta manzilingizni Kiriting");
                        dto.EmailAddress = Console.ReadLine();

                        Console.WriteLine("Parolingizni Kiriting");
                        dto.Password = Console.ReadLine();

                        Console.WriteLine("Mamlakatingizni Kiriting");
                        dto.Country = Console.ReadLine();

                        Console.WriteLine("Shahringizni Kiriting");
                        dto.City = Console.ReadLine();
                        
                        Console.WriteLine("Ko'cha manzilingizni Kiriting");
                        dto.StreetAddress = Console.ReadLine();

                        Console.WriteLine("Zip/Pochtamiz manzili Kiriting");
                        dto.ZipPostalCode = long.Parse(Console.ReadLine());

                        Console.WriteLine("Telefon raqamingizni Kiriting");
                        dto.PhoneNumber = Console.ReadLine();

                        Console.WriteLine("To'lov ma'lumotlaringizni Kiriting");
                        Console.WriteLine("1 => Click");
                        Console.WriteLine("2 => Payme");
                        Console.WriteLine("3 => PayPal");
                        Console.WriteLine("4 => BankTransfer");
                        Console.WriteLine("5 => Oson");
                        dto.PaymentInformation = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), Console.ReadLine());

                        Console.WriteLine("Hisobingizdagi Balansingizni Kiriting");
                        dto.Balance = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Tug'ilgan kuningizni Kiriting (YYYY-MM-DD formatda)");
                        dto.DateOfBirth = DateTime.Parse(Console.ReadLine());

                        var UserIsCreatead = await userService.CreateAsync(dto);
                        Console.WriteLine(UserIsCreatead.FirstName + " Your account is successfully created as Customer");
                        break;
                    case 2:
                        var MerchantService = new MerchantService();
                        MerchantForCreationDto dto2 = new MerchantForCreationDto();

                        Console.WriteLine("Ismingizni Kiriting");
                        dto2.FirstName = Console.ReadLine();

                        Console.WriteLine("Familiyangizni Kiriting");
                        dto2.LastName = Console.ReadLine();

                        Console.WriteLine("O`zingiz Haqida Ma'lumot Kiriting");
                        dto2.MerchantDecription = Console.ReadLine();

                        Console.WriteLine("Telefon raqamingizni Kiriting");
                        dto2.PhoneNumber = Console.ReadLine();

                        Console.WriteLine("Elektron pochta manzilingizni Kiriting");
                        dto2.EmailAddress = Console.ReadLine();

                        Console.WriteLine("Parolingizni Kiriting");
                        dto2.Password = Console.ReadLine();
                        var MerchantIsCreated = await MerchantService.CreateAsync(dto2);
                        Console.WriteLine(MerchantIsCreated.FirstName + " " + "Your account is successfully created as Merchant");
                        break;

                        case 3:
                        var Authorise = new UserAuthentication();
                        Authentification authentification = new Authentification();
                        Console.WriteLine("Kirish");
                        Console.WriteLine("Emailingizni kiriting");
                        authentification.EmailAddress = Console.ReadLine();
                        Console.WriteLine("Parolingizni kiriting");
                        authentification.Password = Console.ReadLine();
                        var IsValid = await Authorise.AuthoriseAsync(authentification);
                        if (IsValid == AuthResult.UserAuthenticated)
                        {
                            while (true)
                            {
                                var userService2 = new UserService();
                                var OrderService = new OrderService();
                                Console.WriteLine("1 => Maxsulotlarni ko`rish");
                                Console.WriteLine("2 => Maxulotga buyurtma berish");
                                Console.WriteLine("3 => Malumotingizni o`zgartirish");
                                Console.WriteLine("4 => Malumotingizni o`chirish");
                                Console.WriteLine("5 => Orqaga qaytish");
                                int UserNum = int.Parse(Console.ReadLine());
                                var ProductService = new ProductService();
                                var UserData = (await userService2.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress);
                                switch (UserNum)
                                {
                                    case 1:
                                        var AllProduct = await ProductService.GetAllAsync();
                                        foreach (var product in AllProduct)
                                        {
                                            Console.WriteLine("Maxsulot Id: " + product.Id);
                                            Console.WriteLine("Maxsulot nomi: " + product.Name);
                                            Console.WriteLine("Maxsulot tavsifi: " + product.Description);
                                            Console.WriteLine("Narxi: " + product.Price);
                                            Console.WriteLine("Kategoriya: " + product.Category);
                                            Console.WriteLine("Brend: " + product.Brand);
                                            Console.WriteLine("miqdori: " + product.StockQuantity);
                                            Console.WriteLine("Sotuvchi ID: " + product.SellerId);
                                            Console.WriteLine("------------");
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Sotib olmoqchi bo`lgan Maxsulot ID sini kiriring");
                                        int GetProductId = int.Parse(Console.ReadLine());
                                        var productService = new ProductService();
                                        var GetProductInfo = await productService.GetByIdAsync(GetProductId);
                                        var OrderInfo = new Orders();
                                        OrderInfo.UserId = UserData.Id;
                                        OrderInfo.ProductId = GetProductId;
                                        var GetProduct = await ProductService.GetByIdAsync(GetProductId);
                                        OrderInfo.Paymentinfo = UserData.PaymentInformation;
                                        Console.WriteLine("Maxsulot miqdorini kiriting");
                                        OrderInfo.ProductQuantity = int.Parse(Console.ReadLine());
                                        OrderInfo.ShippingAddressId = UserData.Country + " " + UserData.City + " " + UserData.StreetAddress;
                                        if (UserData.Balance > OrderInfo.ProductQuantity * GetProduct.Price)
                                        {
                                            Console.WriteLine("Umumiy hisob: " + OrderInfo.ProductQuantity * GetProduct.Price);
                                            Console.WriteLine("Sizning hisobingizda: " + UserData.Balance + " mavjud");
                                            Console.WriteLine("Siz " + GetProductInfo.Name + " Maxsulotni olishga rozimisiz? Ha => 1, Yo`q => 2");
                                            int CheckWhetherPurchase = int.Parse(Console.ReadLine());
                                            if (CheckWhetherPurchase == 1)
                                            {
                                                OrderInfo.TotalAmount = OrderInfo.ProductQuantity * GetProduct.Price;
                                                var UserOrder = await OrderService.PurchaseProductAsync(UserData.Id, GetProductId, OrderInfo);
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Umumiy hisob: " + OrderInfo.ProductQuantity * GetProduct.Price);
                                            Console.WriteLine("Sizning hisobingizda: " + UserData.Balance + " mavjud");
                                            Console.WriteLine("Sizning hisobingizda yetarli mablag` mavjud emas");
                                        }
                                        



                                break;
                                }
                            }
                        }
                        else if (IsValid == AuthResult.MerchantAuthenticated)
                        {
                            Console.WriteLine("Merchant Topildi");
                        }
                        else
                        {
                            Console.WriteLine("Bunday foydalanuvchi yo`q");
                        }
                        break;

                }     
            }
        }
        static void OnAudioPlaybackStopped()
        {
        }
    }
}
