using DL.CategorySystem.Framework.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DL.CategorySystem.Domain.Categories
{
    public class Category : IAggregateRoot
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public int Ordinal { get; private set; }
        public bool Visible { get; private set; }

        public int? ParentCategoryId { get; private set; }
        public Category Parent { get; private set; }

        public IEnumerable<Category> Childen { get; private set; }

        private Category() { }

        public Category(string name, string slug, int ordinal, IEnumerable<Category> children = null)
        {
            // TODO: validation
            this.Name = name;
            this.Slug = slug;
            this.Ordinal = ordinal;
            this.Visible = true;
            this.Childen = children ?? Enumerable.Empty<Category>();
        }
    }
}
