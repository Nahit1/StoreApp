using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StoreApp.Application.Core.DTOs;

namespace StoreApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQuery : IRequest<DefaultPaginationResponse<List<GetAllProductDto>>>
    {
        public string? SearchTerm { get; set; }
        public Guid? Brand { get; set; }
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public List<Guid?> Categories { get; set; }
    }
}
