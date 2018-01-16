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
                .Where(x => x.Parent == null && x.Visible)
                .OrderBy(x => x.Ordinal)
                .Select(Transform);
        }

        private CategoryViewModel Transform(Category category)
        {
            var categoryEntry = _dbContext.Entry(category);
            categoryEntry.Reference(x => x.Parent).Load();
            categoryEntry.Collection(x => x.Childen).Load();

            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Children = category.Childen
                    .Where(x => x.Visible)
                    .OrderBy(x => x.Ordinal)
                    .Select(Transform)
            };
        }
    }
}
