using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Repositories;

namespace StoreApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductHandler
        : IRequestHandler<GetAllProductQuery, DefaultPaginationResponse<List<GetAllProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DefaultPaginationResponse<List<GetAllProductDto>>> Handle(
            GetAllProductQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _productRepository.GetAllProduct(request, cancellationToken);
        }
    }
}
