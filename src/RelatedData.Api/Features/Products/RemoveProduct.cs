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
    public class RemoveProduct
    {
        public class Request : IRequest<Response>
        {
            public Guid ProductId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProductDto Product { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;

            public Handler(IRelatedDataDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.SingleAsync(x => x.ProductId == request.ProductId);

                _context.Products.Remove(product);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Product = product.ToDto()
                };
            }

        }
    }
}
