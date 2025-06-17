using MinimalAPIValidationDemo.Data;
using MinimalAPIValidationDemo.Models;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<PeopleService>();
builder.Services.AddSingleton<OrderService>();

builder.Services.AddValidation();

//interceptors namespaces for validation must included in the property group in the project file
//<InterceptorsNamespaces>$(InterceptorsNamespaces);Microsoft.AspNetCore.Http.Validation.Generated</InterceptorsNamespaces>

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference("/", opt => 
{ 
    opt.Title = "Minimal API Validation Demo";
    opt.Theme = ScalarTheme.Mars;
} );

//map endpoints with validation
app.MapGet("/people", (string? query, PeopleService peopleService) =>
{
    var people = peopleService.GetPeople(query);
    return TypedResults.Ok(people);
});

app.MapPost("/people", (Person person, PeopleService peopleService) =>
{
    peopleService.AddPerson(person);
    return TypedResults.Ok(person);
});

app.MapGet("/orders", (string? query, OrderService orderService) =>
{
    var orders = orderService.GetOrders(query);
    return TypedResults.Ok(orders);
});

app.MapPost("/orders", (Order order, OrderService orderService) =>
{
    orderService.AddOrder(order);
    return TypedResults.Ok(order);
});

app.Run();

