using System;
using System.Threading.Tasks;
using Whatsapp.BLL.Implementation;
using Whatsapp.BLL.Interface;
using WhatsAppDAL.Model;

namespace Whatsapp.BLL.Services.Crud
{
    public class UpdateUser
    {
        private static readonly IWhatsAppService whatsAppService = new WhatsAppService();
        public static async Task User()
        {

            var updateResult = await whatsAppService.UpdateUser(44, new UserViewModel()
            {
                FirstName = "Kelechi",
                LastName = "Amos",
                UserName = "KellynCodes",
                PhoneNumber = "09157060998",
                Country = "Nigeria",
                ProfilePicture = "114628832"
            });
            Console.WriteLine(updateResult > 0 ? "User updated Successfully Deleted" : "User not udated");

        }
    }
}
