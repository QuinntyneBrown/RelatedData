using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using RelatedData.Api.Extensions;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;
using RelatedData.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace RelatedData.Api.Features
{
    public class GetProductsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<ProductDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;

            public Handler(IRelatedDataDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from product in _context.Products
                            select product;

                var length = await _context.Products.CountAsync();

                var products = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = products
                };
            }

        }
    }
}
