using Microsoft.AspNetCore.Identity;

namespace StoreApp.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
