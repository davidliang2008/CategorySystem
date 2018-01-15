using DL.CategorySystem.Domain.Categories;
using DL.CategorySystem.Persistence.EFCore;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace DL.CategorySystem.Reporting.Categories.Queries.Handlers
{
    public class GetCategoriesHandler : RequestHandler<GetCategories, IEnumerable<CategoryViewModel>>
    {
        private readonly AppDbContext _dbContext;

        public GetCategoriesHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IEnumerable<CategoryViewModel> HandleCore(GetCategories query)
        {
            return _dbContext.Categories
                .Where(x => x.Parent == null)
                .OrderBy(x => x.Ordinal)
                .Select(Transform);
        }

        private CategoryViewModel Transform(Category category)
        {
            _dbContext.Entry(category).Collection(x => x.Childen).Load();

            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Slug = category.Slug,
                Children = category.Childen
                    .OrderBy(x => x.Ordinal)
                    .Select(Transform)
            };
        }
    }
}
