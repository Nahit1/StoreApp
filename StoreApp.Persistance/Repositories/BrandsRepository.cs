using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Brands.GetAllBrands;
using StoreApp.Application.Repositories;
using StoreApp.Persistance.Context;

namespace StoreApp.Persistance.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly StoreAppDbContext _context;
        private readonly IMapper _mapper;

        public BrandsRepository(StoreAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DefaultResponse<List<GetAllBrandsDto>>> GetAllBrands(
            GetAllBrandsQuery request,
            CancellationToken cancellationToken
        )
        {
            var brands = await _context
                .Brands.ProjectTo<GetAllBrandsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (brands.Count > 0)
            {
                return DefaultResponse<List<GetAllBrandsDto>>.Successful(brands);
            }

            return new DefaultResponse<List<GetAllBrandsDto>>();
        }
    }
}
