using MediatR;
using StoreApp.Application.Core.DTOs;

namespace StoreApp.Application.Features.Queries.Brands.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<DefaultResponse<List<GetAllBrandsDto>>> { }
}
