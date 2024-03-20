using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Repositories;

namespace StoreApp.Application.Features.Queries.Accounts.LoginUsers
{
    public class LoginUsersHandler
        : IRequestHandler<LoginUsersQuery, DefaultResponse<LoginUsersDto>>
    {
        private readonly IAccountRepository _accountRepository;

        public LoginUsersHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<DefaultResponse<LoginUsersDto>> Handle(
            LoginUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _accountRepository.LoginUser(request, cancellationToken);
        }
    }
}
