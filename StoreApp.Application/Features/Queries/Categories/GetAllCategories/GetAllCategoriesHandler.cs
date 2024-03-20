using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Repositories;

namespace StoreApp.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesHandler
        : IRequestHandler<GetAllCategoriesQuery, DefaultResponse<List<GetAllCategoriesDto>>>
    {
        private readonly ICategoriesRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DefaultResponse<List<GetAllCategoriesDto>>> Handle(
            GetAllCategoriesQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _categoryRepository.GetAllCategories(request, cancellationToken);
        }
    }
}
