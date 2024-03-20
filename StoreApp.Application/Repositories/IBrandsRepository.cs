using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Brands.GetAllBrands;

namespace StoreApp.Application.Repositories
{
    public interface IBrandsRepository
    {
        Task<DefaultResponse<List<GetAllBrandsDto>>> GetAllBrands(
            GetAllBrandsQuery request,
            CancellationToken cancellationToken
        );
    }
}
