using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Application.Core.DTOs;
using StoreApp.Application.Features.Queries.Categories.GetAllCategories;

namespace StoreApp.Application.Repositories
{
    public interface ICategoriesRepository
    {
        Task<DefaultResponse<List<GetAllCategoriesDto>>> GetAllCategories(
            GetAllCategoriesQuery request,
            CancellationToken cancellationToken
        );
    }
}
