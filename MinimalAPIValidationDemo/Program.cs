using MinimalAPIValidationDemo.Data;
using MinimalAPIValidationDemo.Models;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<OrderService>();

builder.Services.AddValidation();

// validation interceptors namespace must be included in the property group in the csproj file
//<InterceptorsNamespaces>$(InterceptorsNamespaces);Microsoft.AspNetCore.Http.Validation.Generated</InterceptorsNamespaces>

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference("/", opt => 
{ 
    opt.Title = "Minimal API Validation Demo";
    opt.Theme = ScalarTheme.Mars;
} );

app.MapGet("/orders", (string? query, OrderService orderService) =>
{
    var orders = orderService.GetOrders(query);
    return TypedResults.Ok(orders);
});

app.MapPost("/orders", (OrderDTO order, OrderService orderService) =>
{
    orderService.AddOrder(order);
    return TypedResults.Ok(order);
});

app.Run();

