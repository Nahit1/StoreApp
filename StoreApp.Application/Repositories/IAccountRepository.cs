using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Accounts.LoginUsers;

namespace StoreApp.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<DefaultResponse<LoginUsersDto>> LoginUser(
            LoginUsersQuery request,
            CancellationToken cancellationToken
        );
    }
}
