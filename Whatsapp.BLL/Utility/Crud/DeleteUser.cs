using System;
using Whatsapp.BLL.Implementation;
using Whatsapp.BLL.Interface;

namespace Whatsapp.BLL.Utility.Crud
{
    public class DeleteUser
    {
        private readonly static IWhatsAppService whatsAppService = new WhatsAppService();
        public static void User()
        {
           start: Console.WriteLine("Enter the id of user you want to delete.");
            if(int.TryParse(Console.ReadLine(), out int userID))
            {
                whatsAppService.DeleteUser(userID);
            }
            else
            {
                Console.WriteLine("Please make sure you enter only numbers.");
                goto start;
            }
        }
    }
}
