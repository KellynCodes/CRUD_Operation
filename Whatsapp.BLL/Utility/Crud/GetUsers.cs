using System;
using System.Threading.Tasks;
using Whatsapp.BLL.Implementation;
using Whatsapp.BLL.Interface;

namespace Whatsapp.BLL.Services.Crud
{
    public class GetUsers
    {
        private readonly static IWhatsAppService whatsAppService = new WhatsAppService();

        public static async Task User()
        {
                var Users = await whatsAppService.GetUsers();
                foreach(var User in Users)
                {
                Console.WriteLine($"Name : {User.FirstName} \t Email : {User.Country} \t Phone : {User.PhoneNumber} \t Photo : {User.ProfilePicture}");
                }
        }
    }
} 
