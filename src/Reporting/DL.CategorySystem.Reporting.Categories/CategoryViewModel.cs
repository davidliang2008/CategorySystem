using System.Collections.Generic;

namespace DL.CategorySystem.Reporting.Categories
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public IEnumerable<CategoryViewModel> Children { get; set; }
    }
}
