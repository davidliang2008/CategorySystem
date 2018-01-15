using MediatR;
using System.Collections.Generic;

namespace DL.CategorySystem.Reporting.Categories.Queries
{
    public class GetCategories : IRequest<IEnumerable<CategoryViewModel>>
    {
    }
}
