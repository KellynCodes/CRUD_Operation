using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsAppDAL.Model;

namespace Whatsapp.BLL.Interface
{
    public interface IWhatsAppService : IDisposable
    {
        Task CreateUser(UserViewModel user);

        Task<long> UpdateUser(int userId, UserViewModel user);

        Task DeleteUser(int UserId);

        Task<UserViewModel> GetUser(int id);

        Task<IEnumerable<UserViewModel>> GetUsers();
    }
}