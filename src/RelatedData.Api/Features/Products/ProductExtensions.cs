using System;
using RelatedData.Api.Models;

namespace RelatedData.Api.Features
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId
            };
        }

    }
}
