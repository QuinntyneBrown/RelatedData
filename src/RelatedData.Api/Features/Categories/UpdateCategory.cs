using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RelatedData.Api.Core;
using RelatedData.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RelatedData.Api.Features
{
    public class UpdateCategory
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Category).NotNull();
                RuleFor(request => request.Category).SetValidator(new CategoryValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public CategoryDto Category { get; set; }
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
                var category = await _context.Categories.SingleAsync(x => x.CategoryId == request.Category.CategoryId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Category = category.ToDto()
                };
            }
            
        }
    }
}
