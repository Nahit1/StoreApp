using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;

namespace StoreApp.Application.Features.Queries.Accounts.LoginUsers
{
    public class LoginUsersQuery : IRequest<DefaultResponse<LoginUsersDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
