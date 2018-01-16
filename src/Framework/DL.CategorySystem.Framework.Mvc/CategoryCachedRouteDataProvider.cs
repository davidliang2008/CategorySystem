using DL.CategorySystem.Domain.Categories;
using DL.CategorySystem.Persistence.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.CategorySystem.Framework.Mvc
{
    public class CategoryCachedRouteDataProvider : ICachedRouteDataProvider<int>
    {
        private readonly AppDbContext _dbContext;

        public CategoryCachedRouteDataProvider(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDictionary<string, int> GetPageToIdMap()
        {
            // Query the categories so we can build all of the URLs client side

            var categories = _dbContext.Categories
                .Where(x => x.Visible == true)
                .ToList();
            var scratch = new StringBuilder();

            return categories
                .Select(x => new KeyValuePair<string, int>(GetUrl(x, categories, scratch), x.CategoryId))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private string GetUrl(Category category, IEnumerable<Category> categories, StringBuilder result)
        {
            result.Clear().Append(category.Slug);
            while ((category = categories.FirstOrDefault(c => c.CategoryId == category.ParentCategoryId)) != null)
            {
                result.Insert(0, String.Concat(category.Slug, "/"));
            }
            return result.ToString();
        }
    }
}
