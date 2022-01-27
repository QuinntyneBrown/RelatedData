using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RelatedData.Api.Models;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;

namespace RelatedData.Api.Features
{
    public class CreateProduct
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Product).NotNull();
                RuleFor(request => request.Product).SetValidator(new ProductValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProductDto Product { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProductDto Product { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IRelatedDataDbContext _context;
        
            public Handler(IRelatedDataDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = new Product();
                
                _context.Products.Add(product);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Product = product.ToDto()
                };
            }
            
        }
    }
}
