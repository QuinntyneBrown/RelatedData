using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using RelatedData.Api.Models;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;

namespace RelatedData.Api.Features
{
    public class RemoveCategory
    {
        public class Request : IRequest<Response>
        {
            public Guid CategoryId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CategoryDto Category { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;

            public Handler(IRelatedDataDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.SingleAsync(x => x.CategoryId == request.CategoryId);

                _context.Categories.Remove(category);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Category = category.ToDto()
                };
            }

        }
    }
}
