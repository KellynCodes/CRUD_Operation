using System;
using System.Threading.Tasks;
using Whatsapp.BLL.Implementation;
using Whatsapp.BLL.Interface;

namespace Whatsapp.BLL.Services.Crud
{
    public class GetUser
    {
        private readonly static IWhatsAppService whatsAppService = new WhatsAppService();

        public static async Task User()
        {
        Start: Console.WriteLine("Enter user id.");
            if (int.TryParse(Console.ReadLine(), out int userID))
            {
                var User = await whatsAppService.GetUser(userID);
                Console.WriteLine($"Name : {User.FirstName} \t Email : {User.Country} \t Phone : {User.PhoneNumber} \t Photo : {User.ProfilePicture}");
            }
            else
            {
                Console.WriteLine("Please make sure your input contains only number.");
                goto Start;
            }
        }
    }
}
