using System.Collections.Generic;

namespace DL.CategorySystem.Framework.Mvc
{
    public interface ICachedRouteDataProvider<TPrimaryKey>
    {
        IDictionary<string, TPrimaryKey> GetPageToIdMap();
    }
}
