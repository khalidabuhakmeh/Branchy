using System;
using Microsoft.AspNetCore.Routing;

namespace Branchy
{
    public static class NestedEndpointsExtensions
    {
        /// <summary>
        /// Creates a structural path to register routes within the path
        /// </summary>
        /// <param name="app"></param>
        /// <param name="route"></param>
        /// <param name="endpoints"></param>
        public static void Path(
            this IEndpointRouteBuilder app,
            string route,
            Action<NestedEndpointConventionBuilder> endpoints)
        {
            var nestedEndpointConventionBuilder =
                new NestedEndpointConventionBuilder(app, route, endpoints);
        }
    }
}