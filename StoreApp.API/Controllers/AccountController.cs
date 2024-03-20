using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.Features.Queries.Accounts.LoginUsers;

namespace StoreApp.API.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginUsersQuery command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
