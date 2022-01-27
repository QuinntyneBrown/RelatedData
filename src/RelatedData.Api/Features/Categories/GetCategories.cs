using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RelatedData.Api.Features
{
    public class GetCategories
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<CategoryDto> Categories { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;
        
            public Handler(IRelatedDataDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Categories = await _context.Categories.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
