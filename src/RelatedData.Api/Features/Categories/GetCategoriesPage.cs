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
    public class GetCategoriesPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<CategoryDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;

            public Handler(IRelatedDataDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from category in _context.Categories
                            select category;

                var length = await _context.Categories.CountAsync();

                var categories = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = categories
                };
            }

        }
    }
}
