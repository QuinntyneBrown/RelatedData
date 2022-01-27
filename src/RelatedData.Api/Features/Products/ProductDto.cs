using System;

namespace RelatedData.Api.Features
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
