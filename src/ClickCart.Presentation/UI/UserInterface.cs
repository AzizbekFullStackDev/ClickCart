using ClickCart.Domain.Entities;
using ClickCart.Domain.Enums;
using ClickCart.Service.DTOs.Merchant;
using ClickCart.Service.DTOs.Product;
using ClickCart.Service.DTOs.User;
using ClickCart.Service.Interfaces;
using ClickCart.Service.Services;
using NAudio.Wave;

namespace ClickCart.Presentation.UI
{
    public class UserInterface
    {
        public async Task RunCodeAsync()
        {

            //  #region 

            string audioFilePath2 = "../../../../ClickCart.Presentation/UI/sword.m4a"; // Replace with the actual path to your audio file

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

            string audioFilePath = "../../../../ClickCart.Presentation/UI/Intro.m4a"; // Replace with the actual path to your audio file

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
            MainMenu:
                try
                {
                    Console.WriteLine("1 => Foydalanuvchi sifatida ro`yhatdan o`tish");
                    Console.WriteLine("2 => Kirish");
                    int num = int.Parse(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            var RegistrationService = new RegistrationService();
                            Registration registration = new Registration();

                            Console.WriteLine("Ismingizni kiriting");
                            registration.FirstName = Console.ReadLine();

                            Console.WriteLine("Familiyangizni kiriting");
                            registration.LastName = Console.ReadLine();

                            Console.WriteLine("Email manzilingizni kiriting");
                            registration.EmailAddress = Console.ReadLine();

                            Console.WriteLine("Parolingizni kiriting");
                            registration.Password = Console.ReadLine();

                            Console.WriteLine("Telefon raqamingizni kiriting");
                            registration.PhoneNumber = Console.ReadLine();

                            Console.WriteLine("Ro'lingizni tanlang (1 => User / 2=> Merchant)");
                            int SelectRole = int.Parse(Console.ReadLine());
                            switch (SelectRole)
                            {
                                case 1:
                                    var userService = new UserService();
                                    var dto = new UserForCreationDto();

                                    dto.FirstName = registration.FirstName;

                                    dto.LastName = registration.LastName;

                                    Console.WriteLine("Foydalanuvchi nomingizni Kiriting");
                                    dto.Username = Console.ReadLine();

                                    dto.EmailAddress = registration.EmailAddress;

                                    dto.Password = registration.Password;

                                    Console.WriteLine("Mamlakatingizni Kiriting");
                                    dto.Country = Console.ReadLine();

                                    Console.WriteLine("Shahringizni Kiriting");
                                    dto.City = Console.ReadLine();

                                    Console.WriteLine("Ko'cha manzilingizni Kiriting");
                                    dto.StreetAddress = Console.ReadLine();

                                    Console.WriteLine("Zip/Pochtamiz manzili Kiriting");
                                    dto.ZipPostalCode = long.Parse(Console.ReadLine());

                                    dto.PhoneNumber = registration.PhoneNumber;

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
                                    Console.WriteLine(UserIsCreatead.FirstName + " Sizning hisobingiz muvaffaqiyatli yaratildi");
                                    break;
                                case 2:
                                    var MerchantService = new MerchantService();
                                    MerchantForCreationDto dto2 = new MerchantForCreationDto();

                                    dto2.FirstName = registration.FirstName;

                                    dto2.LastName = registration.LastName;

                                    Console.WriteLine("O`zingiz Haqida Ma'lumot Kiriting");
                                    dto2.MerchantDecription = Console.ReadLine();

                                    dto2.PhoneNumber = registration.PhoneNumber;

                                    dto2.EmailAddress = registration.EmailAddress;

                                    dto2.Password = registration.Password;
                                    var MerchantIsCreated = await MerchantService.CreateAsync(dto2);
                                    Console.WriteLine(MerchantIsCreated.FirstName + " " + "Sizning hisobingiz muvaffaqiyatli yaratildi");
                                    break;
                            }
                            break;

                        case 2:
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
                                bool back = true;
                                while (back)
                                {
                                BackToUserMenu:

                                    try
                                    {
                                        var userService2 = new UserService();
                                        var OrderService = new OrderService();
                                        Console.WriteLine("1 => Maxsulot Qidirish");
                                        Console.WriteLine("2 => Barcha Maxsulotlarni ko`rish");
                                        Console.WriteLine("3 => Maxsulotga buyurtma berish");
                                        Console.WriteLine("4 => Buyurtmalarni Ko`rish");
                                        Console.WriteLine("5 => O`zingiz haqingizda ma'lumotingizni olish");
                                        Console.WriteLine("6 => Ma'lumotingizni yangilash");
                                        Console.WriteLine("7 => Orqaga qaytish");
                                        int UserNum = int.Parse(Console.ReadLine());
                                        var ProductService = new ProductService();
                                        var UserData = (await userService2.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress);
                                        switch (UserNum)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Maxsulot nomini kiriting");
                                                string SearchProductByName = Console.ReadLine();
                                                var ResultAfterSearch = (await ProductService.GetAllAsync()).Where(e => e.Name.ToLower() == SearchProductByName.ToLower()).ToList();
                                                if (ResultAfterSearch.Count == 0)
                                                {
                                                    Console.WriteLine("Maxsulot topilmadi");
                                                }
                                                else
                                                {
                                                    foreach (var product in ResultAfterSearch)
                                                    {
                                                        Console.WriteLine("===========================================");
                                                        Console.WriteLine("Maxsulot Id: " + product.Id);
                                                        Console.WriteLine("Maxsulot nomi: " + product.Name);
                                                        Console.WriteLine("Maxsulot tavsifi: " + product.Description);
                                                        Console.WriteLine("Narxi: " + product.Price);
                                                        Console.WriteLine("Kategoriya: " + product.Category);
                                                        Console.WriteLine("Brend: " + product.Brand);
                                                        Console.WriteLine("miqdori: " + product.StockQuantity);
                                                        Console.WriteLine("Sotuvchi ID: " + product.MerchantId);
                                                        Console.WriteLine("===========================================");
                                                    }
                                                }
                                                break;
                                            case 2:
                                                Console.Clear();
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
                                                    Console.WriteLine("Sotuvchi ID: " + product.MerchantId);
                                                    Console.WriteLine("------------");
                                                }
                                                break;
                                            case 3:
                                                Console.WriteLine("Sotib olmoqchi bo`lgan Maxsulot ID sini kiriring");
                                                int GetProductId = int.Parse(Console.ReadLine());
                                                var productService = new ProductService();
                                                var GetProductInfo = await productService.GetByIdAsync(GetProductId);
                                                var OrderInfo = new Orders();
                                                OrderInfo.UserId = UserData.Id;
                                                OrderInfo.ProductId = GetProductId;
                                                var GetProduct = await ProductService.GetByIdAsync(GetProductId);
                                                OrderInfo.PaymentMethod = UserData.PaymentInformation;
                                                Console.WriteLine("Maxsulot miqdorini kiriting");
                                                OrderInfo.ProductQuantity = int.Parse(Console.ReadLine());
                                                OrderInfo.Country = UserData.Country;
                                                OrderInfo.City = UserData.City;
                                                OrderInfo.street = UserData.StreetAddress;
                                                OrderInfo.ZipCode = UserData.ZipPostalCode;
                                                if (UserData.Balance > OrderInfo.ProductQuantity * GetProduct.Price)
                                                {
                                                    Console.WriteLine("Umumiy hisob: " + OrderInfo.ProductQuantity * GetProduct.Price);
                                                    Console.WriteLine("Sizning hisobingizda: " + UserData.Balance + " mavjud");
                                                    Console.WriteLine("Siz " + GetProductInfo.Name + " Maxsulotni olishga rozimisiz? Ha => 1, Yo`q => 2");
                                                    int CheckWhetherPurchase = int.Parse(Console.ReadLine());
                                                    if (CheckWhetherPurchase == 1)
                                                    {
                                                        OrderInfo.TotalAmount = OrderInfo.ProductQuantity * GetProduct.Price;
                                                        var UserUpdateBalance = new UserForUpdateDto()
                                                        {
                                                            Id = UserData.Id,
                                                            Balance = UserData.Balance - OrderInfo.TotalAmount
                                                        };
                                                        await userService2.UpdateBalanceAsync(UserUpdateBalance);

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
                                            case 4:
                                                Console.Clear();
                                                var GetAllOrders = (await OrderService.GetAllOrdersAsync()).Where(e => e.UserId == UserData.Id);
                                                foreach (var item in GetAllOrders)
                                                {
                                                    Console.WriteLine("Maxsulot Id: " + item.ProductId);
                                                    var GetProductNameById = await ProductService.GetByIdAsync(item.ProductId);
                                                    Console.WriteLine("Maxsulot nomi: " + GetProductNameById.Name);
                                                    Console.WriteLine("Maxsulot tavsifi: " + item.ProductId);
                                                    Console.WriteLine("Narxi: " + item.TotalAmount);
                                                    Console.WriteLine("Narxi: " + item.ProductQuantity);
                                                    Console.WriteLine("Buyurtma berildi : " + item.CreatedAt);
                                                    Console.WriteLine("Yetkazib berish Manzili: Shaxar" + item.City + " mahalla nomi: " + item.street + " Pochta indeksi " + item.ZipCode);
                                                    Console.WriteLine("To`lov usuli: " + item.PaymentMethod);
                                                    Console.WriteLine("Buyurtma Holat: " + item.OrderStatus);
                                                    Console.WriteLine("------------");
                                                }
                                                break;
                                            case 5:
                                                Console.Clear();

                                                Console.WriteLine("Ismingiz: " + UserData.FirstName);
                                                Console.WriteLine("Familiyangiz: " + UserData.LastName);
                                                Console.WriteLine("Foydalanuvchi nomingiz: " + UserData.Username);
                                                Console.WriteLine("Email manzil: " + UserData.EmailAddress);
                                                Console.WriteLine("Parol: " + UserData.Password);
                                                Console.WriteLine("Ko'cha manzili: " + UserData.StreetAddress);
                                                Console.WriteLine("Shahar: " + UserData.City);
                                                Console.WriteLine("Zip/Pochtamiz manzili: " + UserData.ZipPostalCode);
                                                Console.WriteLine("Mamlakat: " + UserData.Country);
                                                Console.WriteLine("Telefon raqami: " + UserData.PhoneNumber);
                                                Console.WriteLine("To'lov ma'lumotlari: " + UserData.PaymentInformation);
                                                Console.WriteLine("Hisob: " + UserData.Balance);
                                                Console.WriteLine("Tug'ilgan kuni: " + UserData.DateOfBirth.ToString("yyyy-MM-dd"));

                                                break;
                                            case 6:
                                                Console.Clear();
                                                var userService3 = new UserService();

                                                var UserData2 = new UserForUpdateDto();
                                                UserData2.Id = UserData.Id;
                                                Console.WriteLine("Ismingizni kiriting");
                                                UserData2.FirstName = GetUserInput("Ismingizni kiriting", UserData.FirstName);

                                                Console.WriteLine("Familiyangizni kiriting");
                                                UserData2.LastName = GetUserInput("Familiyangizni kiriting", UserData.LastName);

                                                UserData2.EmailAddress = UserData.EmailAddress;

                                                UserData2.Password = UserData.Password;

                                                Console.WriteLine("Telefon raqamingizni kiriting");
                                                UserData2.PhoneNumber = GetUserInput("Telefon raqamingizni kiriting", UserData.PhoneNumber);

                                                Console.WriteLine("Foydalanuvchi nomingizni Kiriting (Bo`sh qoldirish uchun Enter tugmasini bosing)");
                                                UserData2.Username = GetUserInput("Foydalanuvchi nomingizni Kiriting", UserData.Username);

                                                Console.WriteLine("Mamlakatingizni Kiriting");
                                                UserData2.Country = GetUserInput("Mamlakatingizni Kiriting", UserData.Country);

                                                Console.WriteLine("Shahringizni Kiriting");
                                                UserData2.City = GetUserInput("Shahringizni Kiriting", UserData.City);

                                                Console.WriteLine("Ko'cha manzilingizni Kiriting");
                                                UserData2.StreetAddress = GetUserInput("Ko'cha manzilingizni Kiriting", UserData.StreetAddress);

                                                Console.WriteLine("Zip/Pochtamiz manzili Kiriting");
                                                UserData2.ZipPostalCode = long.Parse(GetUserInput("Zip/Pochtamiz manzili Kiriting", UserData.ZipPostalCode.ToString()));

                                                Console.WriteLine("To'lov ma'lumotlaringizni Kiriting");
                                                Console.WriteLine("1 => Click");
                                                Console.WriteLine("2 => Payme");
                                                Console.WriteLine("3 => PayPal");
                                                Console.WriteLine("4 => BankTransfer");
                                                Console.WriteLine("5 => Oson");
                                                UserData2.PaymentInformation = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), GetUserInput("To'lov ma'lumotlaringizni Kiriting", UserData.PaymentInformation.ToString()));

                                                Console.WriteLine("Hisobingizdagi Balansingizni Kiriting");
                                                UserData2.Balance = decimal.Parse(GetUserInput("Hisobingizdagi Balansingizni Kiriting", UserData.Balance.ToString()));

                                                Console.WriteLine("Tug'ilgan kuningizni Kiriting (YYYY-MM-DD formatda)");
                                                UserData2.DateOfBirth = DateTime.Parse(GetUserInput("Tug'ilgan kuningizni Kiriting (YYYY-MM-DD formatda)", UserData.DateOfBirth.ToString()));

                                                var UserIsCreated = await userService3.UpdateAsync(UserData2);
                                                Console.WriteLine(UserIsCreated.FirstName + " Sizning hisobingiz muvaffaqiyatli yangilandi");

                                                // Create a method to handle user input and return either the new input or the existing value
                                                string GetUserInput(string prompt, string currentValue)
                                                {
                                                    Console.WriteLine(prompt + " (Enter to skip, current value: " + currentValue + ")");
                                                    string userInput = Console.ReadLine();
                                                    return string.IsNullOrEmpty(userInput) ? currentValue : userInput;
                                                }
                                                break;
                                            case 7:
                                                back = false;
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        goto BackToUserMenu;
                                    }
                                }
                            }
                            else if (IsValid == AuthResult.MerchantAuthenticated)
                            {
                                bool GoBack = true;
                                while (GoBack)
                                {
                                BackToMerchantMenu:
                                    try
                                    {
                                        MerchantService merchantService = new MerchantService();
                                        ProductService ProductService = new ProductService();
                                        Console.WriteLine("1 => Maxsulot Qo`shish");
                                        Console.WriteLine("2 => Barcha Maxsulotlarni ko`rish");
                                        Console.WriteLine("3 => Mening maxsulotlarim");
                                        Console.WriteLine("4 => Maxsulot sotuvini ko`rish");
                                        Console.WriteLine("5 => O`zingiz haqingizda ma'lumotingizni olish");
                                        Console.WriteLine("6 => Ma'lumotingizni yangilash");
                                        Console.WriteLine("7 => Orqaga qaytish");
                                        int GetNumForMerchantMenu = int.Parse(Console.ReadLine());

                                        switch (GetNumForMerchantMenu)
                                        {
                                            case 1:
                                                ProductForCreationDto ProductCreation = new ProductForCreationDto();

                                                Console.WriteLine("Maxsulot nomini kiriting:");
                                                ProductCreation.Name = Console.ReadLine();

                                                Console.WriteLine("Maxsulotning tavsifi kiriting:");
                                                ProductCreation.Description = Console.ReadLine();

                                                Console.WriteLine("Maxsulot narxini kiriting:");
                                                ProductCreation.Price = decimal.Parse(Console.ReadLine());


                                                Console.WriteLine("1 => Computers");
                                                Console.WriteLine("2 => SmartPhones");
                                                Console.WriteLine("3 => HeadPhones");
                                                Console.WriteLine("4 => Cameras");
                                                Console.WriteLine("5 => ComputerComponents");
                                                Console.WriteLine("6 => Printers");
                                                Console.WriteLine("7 => Connectors");
                                                Console.WriteLine("8 => GamingComponents");

                                                Console.WriteLine("Maxsulot kategoriyasini kiriting:");
                                                ProductCreation.Category = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine()); ;

                                                Console.WriteLine("Maxsulot brendini kiriting:");
                                                ProductCreation.Brand = Console.ReadLine();

                                                Console.WriteLine("Maxsulot miqdorini kiriting:");
                                                ProductCreation.StockQuantity = decimal.Parse(Console.ReadLine());
                                                var GetExactMerchant = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress && e.Password == authentification.Password);

                                                ProductCreation.MerchantId = GetExactMerchant.Id;
                                                var ProductisCreated = await ProductService.CreateAsync(ProductCreation);
                                                Console.WriteLine(ProductisCreated.Name + " nomli maxsulot qo`shildi");

                                                break;
                                            case 2:
                                                Console.Clear();
                                                var AllProducts = await ProductService.GetAllAsync();
                                                foreach (var product in AllProducts)
                                                {
                                                    Console.WriteLine("===========================================");
                                                    Console.WriteLine("Maxsulot Id: " + product.Id);
                                                    Console.WriteLine("Maxsulot nomi: " + product.Name);
                                                    Console.WriteLine("Maxsulot tavsifi: " + product.Description);
                                                    Console.WriteLine("Narxi: " + product.Price);
                                                    Console.WriteLine("Kategoriya: " + product.Category);
                                                    Console.WriteLine("Brend: " + product.Brand);
                                                    Console.WriteLine("miqdori: " + product.StockQuantity);
                                                    Console.WriteLine("Sotuvchi ID: " + product.MerchantId);
                                                    Console.WriteLine("===========================================");
                                                }
                                                break;
                                            case 3:
                                                Console.Clear();
                                                var GetExactMerchantId = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress && e.Password == authentification.Password);
                                                var MyProducts = (await ProductService.GetAllAsync()).Where(e => e.MerchantId == GetExactMerchantId.Id);
                                                foreach (var product in MyProducts)
                                                {
                                                    Console.WriteLine("===========================================");
                                                    Console.WriteLine("Maxsulot Id: " + product.Id);
                                                    Console.WriteLine("Maxsulot nomi: " + product.Name);
                                                    Console.WriteLine("Maxsulot tavsifi: " + product.Description);
                                                    Console.WriteLine("Narxi: " + product.Price);
                                                    Console.WriteLine("Kategoriya: " + product.Category);
                                                    Console.WriteLine("Brend: " + product.Brand);
                                                    Console.WriteLine("miqdori: " + product.StockQuantity);
                                                    Console.WriteLine("Sotuvchi ID: " + product.MerchantId);
                                                    Console.WriteLine("===========================================");
                                                }
                                                break;
                                            case 4:
                                                var GetExactMerchantIdForSold = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress && e.Password == authentification.Password);
                                                var MyProductsSold = (await ProductService.GetAllAsync()).Where(e => e.MerchantId == GetExactMerchantIdForSold.Id);
                                                var OrderService = new OrderService();
                                                foreach (var product2 in MyProductsSold)
                                                {
                                                    var MySoldProducts = (await OrderService.GetAllOrdersAsync()).Where(e => e.ProductId == product2.Id);
                                                    foreach (var product in MySoldProducts)
                                                    {
                                                        var GetExactMerchantNameForSold = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.Id == product.UserId);
                                                        Console.WriteLine("===========================================");
                                                        Console.WriteLine("Maxsulot Id: " + product.Id);
                                                        Console.WriteLine("Maxsulot nomi: " + product.ProductName);
                                                        Console.WriteLine("Sotilgan Maxsulot soni: " + product.ProductQuantity);
                                                        Console.WriteLine("Yetkazib berish manzili: " + product.Country + " " + product.City + " " + product.street);
                                                        Console.WriteLine("Buyurtma Sanasi: " + product.CreatedAt);
                                                        Console.WriteLine("Buyurtma holati: " + product.OrderStatus);
                                                        Console.WriteLine("Sotilgan Maxsulotning umumiy Narxi: " + product.TotalAmount);
                                                        Console.WriteLine("To`lov Usuli: " + product.PaymentMethod);
                                                        Console.WriteLine("Zipcode: " + product.ZipCode);
                                                        Console.WriteLine("Xaridor Ismi: " + GetExactMerchantNameForSold.FirstName);
                                                        Console.WriteLine("===========================================");
                                                    }

                                                }
                                                break;
                                            case 5:
                                                var GetExactMerchantInfo = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress && e.Password == authentification.Password);
                                                Console.WriteLine("ID: " + GetExactMerchantInfo.Id);
                                                Console.WriteLine("Ismingiz: " + GetExactMerchantInfo.FirstName);
                                                Console.WriteLine("Familiyangiz: " + GetExactMerchantInfo.LastName);
                                                Console.WriteLine("Siz haqingizda qisqacha ma'lumot: " + GetExactMerchantInfo.MerchantDecription);
                                                Console.WriteLine("Telefon raqamingiz: " + GetExactMerchantInfo.PhoneNumber);
                                                Console.WriteLine("Email pochta: " + GetExactMerchantInfo.EmailAddress);
                                                Console.WriteLine("Parol: " + GetExactMerchantInfo.Password);
                                                break;
                                            case 6:
                                                var GetExactMerchantInfoForupdate = (await merchantService.GetAllAsync()).FirstOrDefault(e => e.EmailAddress == authentification.EmailAddress && e.Password == authentification.Password);
                                                var merchantUpdate = new MerchantForUpdateDto();
                                                var MerchantService = new MerchantService();
                                                merchantUpdate.Id = GetExactMerchantInfoForupdate.Id;

                                                Console.WriteLine("Ismingizni kiriting");
                                                merchantUpdate.FirstName = GetUserInput(GetExactMerchantInfoForupdate.FirstName);

                                                Console.WriteLine("Familiyangizni kiriting");
                                                merchantUpdate.LastName = GetUserInput(GetExactMerchantInfoForupdate.LastName);

                                                merchantUpdate.EmailAddress = GetExactMerchantInfoForupdate.EmailAddress;

                                                merchantUpdate.Password = GetExactMerchantInfoForupdate.Password;

                                                Console.WriteLine("Telefon raqamingizni kiriting");
                                                merchantUpdate.PhoneNumber = GetUserInput(GetExactMerchantInfoForupdate.PhoneNumber);

                                                Console.WriteLine("O`zingiz haqingizda ma'lumot kiriting");
                                                merchantUpdate.MerchantDecription = GetUserInput(GetExactMerchantInfoForupdate.MerchantDecription);

                                                var MerchantIsCreated = await MerchantService.UpdateAsync(merchantUpdate);
                                                Console.WriteLine(MerchantIsCreated.FirstName + " " + "Sizning hisobingiz muvaffaqiyatli yangilandi");
                                                string GetUserInput(string currentValue)
                                                {
                                                    Console.WriteLine(" (O`tkazib yuborish uchun <<Enter>> tugmasini boing, Hozigi Ma'lumot: " + currentValue + ")");
                                                    string userInput = Console.ReadLine();
                                                    return string.IsNullOrEmpty(userInput) ? currentValue : userInput;
                                                }

                                                break;
                                            case 7:
                                                GoBack = false;
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        goto BackToMerchantMenu;
                                    }
                                }
                            }
                            else if (IsValid == AuthResult.SuperAdmin)
                            {
                                bool forward = true;
                                while (forward)
                                {
                                BackToSuperAdminMenu:
                                    try
                                    {
                                        Console.WriteLine("1 => Sotuvchilarni maxsulotlarini ko`rish");
                                        Console.WriteLine("2 => Barcha Buyurtmalarni ko`rish");
                                        int numberAdmin = int.Parse(Console.ReadLine());

                                        switch (numberAdmin)
                                        {
                                            case 1:
                                                var MerchantProduct = new ProductMerchantService();
                                                var AllProductwithMerchantInfo = await MerchantProduct.GetAllProductsWithMerchantsInfoAsync();
                                                foreach (var product in AllProductwithMerchantInfo)
                                                {
                                                    Console.WriteLine("------------------------");
                                                    Console.WriteLine("Product Id: " + product.ProductId);
                                                    Console.WriteLine("Merchant Id: " + product.MerchantId);
                                                    Console.WriteLine("Merchant Name: " + product.MerchantName);
                                                    Console.WriteLine("Product Name: " + product.ProductName);
                                                    Console.WriteLine("Product Description: " + product.ProductDescription);
                                                    Console.WriteLine("Product Price: " + product.ProductPrice);
                                                    Console.WriteLine("Product Category: " + product.ProductCategory);
                                                    Console.WriteLine("Product Brand: " + product.ProductBrand);
                                                    Console.WriteLine("Product Stock Quantity: " + product.ProductStockQuantity);
                                                    Console.WriteLine("------------------------");
                                                }
                                                break;
                                            case 2:
                                                var Orderservice = new OrderService();
                                                var AllOrders = await Orderservice.GetAllOrdersAsync();
                                                foreach (var order in AllOrders)
                                                {
                                                    Console.WriteLine("------------------------");
                                                    Console.WriteLine("Order Id: " + order.UserId);
                                                    Console.WriteLine("Product Id: " + order.ProductId);
                                                    Console.WriteLine("Product Name: " + order.ProductName);
                                                    Console.WriteLine("Total Amount: " + order.TotalAmount);
                                                    Console.WriteLine("Product Quantity: " + order.ProductQuantity);
                                                    Console.WriteLine("Country: " + order.Country);
                                                    Console.WriteLine("City: " + order.City);
                                                    Console.WriteLine("Street: " + order.street);
                                                    Console.WriteLine("Zip Code: " + order.ZipCode);
                                                    Console.WriteLine("Payment Method: " + order.PaymentMethod);
                                                    Console.WriteLine("Order Status: " + order.OrderStatus);
                                                    Console.WriteLine("------------------------");


                                                }
                                                // Code to handle option 2
                                                break;
                                            default:
                                                Console.WriteLine("Invalid option. Please try again.");
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        goto BackToSuperAdminMenu;
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("Bunday foydalanuvchi yo`q");
                            }
                            break;

                    }
                }
                catch (Exception)
                {
                    goto MainMenu;
                }
                }  
            }
        static void OnAudioPlaybackStopped() { }
        
    }
}
