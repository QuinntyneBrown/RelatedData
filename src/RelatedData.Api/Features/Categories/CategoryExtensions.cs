using System;
using RelatedData.Api.Models;

namespace RelatedData.Api.Features
{
    public static class CategoryExtensions
    {
        public static CategoryDto ToDto(this Category category)
        {
            return new ()
            {
                CategoryId = category.CategoryId,
                Name = category.Name
                
            };
        }
        
    }
}
