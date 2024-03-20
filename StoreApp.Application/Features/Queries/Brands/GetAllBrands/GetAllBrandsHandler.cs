using MediatR;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Repositories;

namespace StoreApp.Application.Features.Queries.Brands.GetAllBrands
{
    public class GetAllBrandsHandler
        : IRequestHandler<GetAllBrandsQuery, DefaultResponse<List<GetAllBrandsDto>>>
    {
        private readonly IBrandsRepository _brandRepository;

        public GetAllBrandsHandler(IBrandsRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<DefaultResponse<List<GetAllBrandsDto>>> Handle(
            GetAllBrandsQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _brandRepository.GetAllBrands(request, cancellationToken);
        }
    }
}
