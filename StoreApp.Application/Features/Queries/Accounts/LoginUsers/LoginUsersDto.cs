using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Application.Features.Queries.Accounts.LoginUsers
{
    public class LoginUsersDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public TokenDto Token { get; set; }
    }

    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
