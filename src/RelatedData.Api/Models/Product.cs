using System;

namespace RelatedData.Api.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
