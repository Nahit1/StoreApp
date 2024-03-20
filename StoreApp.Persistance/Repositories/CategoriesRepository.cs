using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Categories.GetAllCategories;
using StoreApp.Application.Repositories;
using StoreApp.Persistance.Context;

namespace StoreApp.Persistance.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly StoreAppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesRepository(StoreAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DefaultResponse<List<GetAllCategoriesDto>>> GetAllCategories(
            GetAllCategoriesQuery request,
            CancellationToken cancellationToken
        )
        {
            var categories = await _context
                .Categories.ProjectTo<GetAllCategoriesDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return DefaultResponse<List<GetAllCategoriesDto>>.Successful(categories);
        }
    }
}
