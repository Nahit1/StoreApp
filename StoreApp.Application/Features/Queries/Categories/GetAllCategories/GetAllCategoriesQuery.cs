using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;

namespace StoreApp.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<DefaultResponse<List<GetAllCategoriesDto>>> { }
}
