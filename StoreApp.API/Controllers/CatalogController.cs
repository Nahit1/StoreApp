using Microsoft.AspNetCore.Mvc;
using StoreApp.Application.Features.Queries.Brands.GetAllBrands;
using StoreApp.Application.Features.Queries.Categories.GetAllCategories;
using StoreApp.Application.Features.Queries.Product.GetAllProduct;

namespace StoreApp.API.Controllers
{
    public class CatalogController : BaseController
    {
        [HttpPost]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllProduct([FromBody] GetAllProductQuery command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQuery command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands([FromQuery] GetAllBrandsQuery command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
