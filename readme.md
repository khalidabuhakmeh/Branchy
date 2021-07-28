# Branchy  - Nested Routing For ASP.NET Core Minimal APIs

![Branchy Logo](./media/Logo%20Horizontal.png)

This library allows ASP.NET Core developers to register routes in a nested way. This reduces the amount of strings representing route patterns.

It's easier to see it, than to explain it.

## Getting Started

**This package works with .NET 6**, so be sure to grab the latest .NET 6.

```console
> dotnet add package Branchy
```

## Sample

```c#
app.Path("/", root =>
{
    root.MapGet(() => "Hello, Nested World!");
    root.Path("todos", todos =>
    {
        todos.MapGet(() => Range(1, 4).Select(i => new Todo(i)));
        todos.Path("{id:int}", t =>
        {
            t.MapGet((int id) =>
            {
                return new Todo(id);
            });

            t.MapDelete((int id, HttpContext ctx) =>
            {
                ctx.Response.StatusCode = StatusCodes.Status202Accepted;
            });
        });
    });
});
```

## Minimal API Gotchas

The new routing approach takes in either a `RequestDelegate` or a `Delegate` that gets implicitly cast. If you are using the OpenAPI swagger gen, be sure to pass your parameters into your delegates, or OpenAPI might not find them (even though your routes may still work).

## License

The MIT License (MIT)
Copyright © 2021 Khalid Abuhakmeh

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.