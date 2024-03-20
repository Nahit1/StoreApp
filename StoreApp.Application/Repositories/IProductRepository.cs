using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Product.GetAllProduct;

namespace StoreApp.Application.Repositories
{
    public interface IProductRepository
    {
        Task<DefaultPaginationResponse<List<GetAllProductDto>>> GetAllProduct(
            GetAllProductQuery request,
            CancellationToken cancellationToken
        );
    }
}
