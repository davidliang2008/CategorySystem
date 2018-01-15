using DL.CategorySystem.Reporting.Categories.Queries.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DL.CategorySystem.Web.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(GetCategoriesHandler).Assembly
            );
        }
    }
}
