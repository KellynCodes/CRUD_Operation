using System;

namespace WhatsAppDAL.Model
{
    public class UserViewModel
    {
        public Guid UserID { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string ProfilePicture { get; set; }
    }
}
