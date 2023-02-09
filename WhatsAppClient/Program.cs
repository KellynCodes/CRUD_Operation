using Whatsapp.BLL.Implementation;
using Whatsapp.BLL.Interface;
using Whatsapp.BLL.Services.Crud;
using Whatsapp.BLL.Utility;
using Whatsapp.BLL.Utility.Crud;
using WhatsAppDAL;
using WhatsAppDAL.Model;


namespace WhatsAppClient
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Hello, World!");

            using IWhatsAppService whatsAppService = new WhatsAppService(new WhatsAppDbContext());
                var userData = new UserViewModel
                {
                    FirstName = "Amaka",
                    LastName = "Chelsea",
                    UserName = "Amaka.Disappoint",
                    PhoneNumber = "09095002355",
                    Country = "Nigeria",
                    ProfilePicture = "123445"
                };

            Console.WriteLine("Welcome!. What would like to do.");
            Console.WriteLine("1. Create User\n 2. Update User.\n 3. Get users.\n 4. Get all user.");
            if(int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case (int)SwitchCases.CaseOne:
                       await whatsAppService.CreateUser(userData);
                        break;
                    case (int)SwitchCases.CaseTwo:
                        await UpdateUser.User();
                        break;
                    case (int)SwitchCases.CaseThree:
                        await GetUser.User();
                        break;
                    case (int)SwitchCases.CaseFour:
                        await GetUsers.User();
                        break;
                    case (int)SwitchCases.CaseFive:
                        DeleteUser.User();
                        break;
                    default: Console.WriteLine("Entered input was not in the list.");
                        break;
                }
            }
        }
    }
}