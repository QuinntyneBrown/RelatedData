using System;
using System.Collections.Generic;

namespace RelatedData.Api.Data
{
    public static class SeedData
    {
        public static void Seed(RelatedDataDbContext context)
        {
            foreach (var categoryName in new List<string>()
            {
                "Household",
                "Sporting Equipment",
                "Grocery"
            })
            {
                var category = new Models.Category() { Name = categoryName };

                context.Categories.Add(category);

                context.SaveChanges();

                var productNames = new List<string>();

                switch (categoryName)
                {
                    case "Household":
                        productNames.AddRange(new string[3] { "Vim", "Toothpaste", "Toilet Paper" });
                        break;

                    case "Sporting Equipment":
                        productNames.AddRange(new string[2] { "Jordans", "Knee Brace" });
                        break;

                    case "Grocery":
                        productNames.AddRange(new string[2] { "Bread", "Chicken" });
                        break;
                }

                foreach (var productName in productNames)
                {
                    context.Products.Add(new Models.Product
                    {
                        Name = productName,
                        CategoryId = category.CategoryId,

                    });
                }

                context.SaveChanges();
            }
        }
    }
}
