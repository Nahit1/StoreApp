using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Product.GetAllProduct;
using StoreApp.Application.Repositories;
using StoreApp.Persistance.Context;

namespace StoreApp.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(StoreAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DefaultPaginationResponse<List<GetAllProductDto>>> GetAllProduct(
            GetAllProductQuery request,
            CancellationToken cancellationToken
        )
        {
            int pageCount = 0;

            var totalCountQuery = _context.Products.Include(c => c.Categories).AsQueryable();

            var query = _context.Products.AsQueryable();
            if (request.Brand != null)
            {
                query = query.Where(p => p.BrandId == request.Brand);
                totalCountQuery = query;
            }

            if (request.Categories.Count > 0 || request.Categories != null)
            {
                query = query.Where(p => p.Categories.Any(x => request.Categories.Contains(x.Id)));
                totalCountQuery = query;
            }

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var lowerCaseSearchTerm = request.SearchTerm.ToLower();
                query = query.Where(p => p.Name.Contains(lowerCaseSearchTerm));
                totalCountQuery = query;
            }

            if (request.PageSize > 0 && request.PageNumber > 0)
            {
                query = query
                    .Skip(request.PageSize * (request.PageNumber - 1))
                    .Take(request.PageSize);
            }

            var products = await query
                .ProjectTo<GetAllProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var totalCount = await totalCountQuery.CountAsync();

            pageCount = (int)Math.Ceiling((double)totalCount / request.PageSize);

            return DefaultPaginationResponse<List<GetAllProductDto>>.Successful(
                products,
                pageCount,
                totalCount
            );
        }
    }
}
