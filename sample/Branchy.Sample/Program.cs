using Branchy;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Path("/", root =>
{
    root.Metadata(c =>
    {
        // .NET 6 rc2 
        if (c is not RouteHandlerBuilder r) return;
        r.ProducesValidationProblem();
        r.ProducesProblem(StatusCodes.Status400BadRequest);
    });
    
    root.MapGet(() => "Hello World!");
    root.MapGet("/hi", () => "hi");
});

app.Run();
