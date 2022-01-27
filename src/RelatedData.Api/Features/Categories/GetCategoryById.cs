using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RelatedData.Api.Features
{
    public class GetCategoryById
    {
        public class Request: IRequest<Response>
        {
            public Guid CategoryId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CategoryDto Category { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;
        
            public Handler(IRelatedDataDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Category = (await _context.Categories.SingleOrDefaultAsync(x => x.CategoryId == request.CategoryId)).ToDto()
                };
            }
            
        }
    }
}
