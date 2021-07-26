using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Branchy
{
    public class NestedEndpointConventionBuilder
    {
        private readonly IEndpointRouteBuilder _app;
        private readonly string _baseRoute;

        internal NestedEndpointConventionBuilder(IEndpointRouteBuilder app, string baseRoute,
            Action<NestedEndpointConventionBuilder> call)
        {
            _app = app;
            _baseRoute = baseRoute;

            // invoke as we go down the chain, it's fine
            call(this);
        }

        /// <summary>
        /// Map a path to register nested routes
        /// </summary>
        /// <param name="route"></param>
        /// <param name="call"></param>
        /// <returns></returns>
        public NestedEndpointConventionBuilder Path(string route, Action<NestedEndpointConventionBuilder> call)
        {
            return new NestedEndpointConventionBuilder(_app, Combine(route), call);
        }

        /// <summary>
        /// Register a root route with the GET method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapGet(Delegate requestDelegate)
        {
            return _app.MapGet(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the GET action using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapGet(RequestDelegate requestDelegate)
        {
            return _app.MapGet(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the GET action using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapGet(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapGet(route, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the GET action using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapGet(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapGet(route, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the POST action using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPost(Delegate requestDelegate)
        {
            return _app.MapPost(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the POST action using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPost(RequestDelegate requestDelegate)
        {
            return _app.MapPost(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the POST action using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPost(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPost(route, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the POST method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPost(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPost(route, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the PUT method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPut(Delegate requestDelegate)
        {
            return _app.MapPut(_baseRoute, requestDelegate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPut(RequestDelegate requestDelegate)
        {
            return _app.MapPut(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the PUT method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPut(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPut(route, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the PUT method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPut(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapPut(route, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the PATCH method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPatch(Delegate requestDelegate)
        {
            return _app.MapMethods(_baseRoute, new []{ HttpMethods.Patch }, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the PATCH method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPatch(RequestDelegate requestDelegate)
        {
            return _app.MapMethods(_baseRoute, new []{ HttpMethods.Patch }, requestDelegate);
        }

        /// <summary>
        /// /// Register a nested route with the PATCH method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPatch(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapMethods(route, new []{ HttpMethods.Patch }, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the PATCH method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapPatch(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapMethods(_baseRoute, new []{ HttpMethods.Patch }, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the DELETE method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapDelete(Delegate requestDelegate)
        {
            return _app.MapDelete(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the DELETE method using the Path template.
        /// </summary>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapDelete(RequestDelegate requestDelegate)
        {
            return _app.MapDelete(_baseRoute, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the DELETE method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapDelete(string pattern, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapDelete(route, requestDelegate);
        }

        /// <summary>
        /// Register a nested route with the DELETE method using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapDelete(string pattern, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapDelete(route, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the any set of methods using the Path template.
        /// </summary>
        /// <param name="methods"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapMethods(IEnumerable<string> methods, RequestDelegate requestDelegate)
        {
            return _app.MapMethods(_baseRoute, methods, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the any set of methods using the Path template.
        /// </summary>
        /// <param name="methods"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapMethods(IEnumerable<string> methods, Delegate requestDelegate)
        {
            return _app.MapMethods(_baseRoute, methods, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the any set of methods using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="methods"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapMethods(string pattern, IEnumerable<string> methods, RequestDelegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapMethods(route, methods, requestDelegate);
        }

        /// <summary>
        /// Register a root route with the any set of methods using the provided pattern.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="methods"></param>
        /// <param name="requestDelegate"></param>
        /// <returns></returns>
        public IEndpointConventionBuilder MapMethods(string pattern, IEnumerable<string> methods, Delegate requestDelegate)
        {
            var route = Combine(pattern);
            return _app.MapMethods(route, methods, requestDelegate);
        }

        private string Combine(string pattern)
        {
            return $"{_baseRoute.TrimEnd('/')}/{pattern.TrimStart('/')}";
        }
    }
}