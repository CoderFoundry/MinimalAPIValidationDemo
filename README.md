# Minimal API Validation Demo

 Explore the powerful new model validation features introduced in .NET 10 Preview—combine familiar DataAnnotations with cutting-edge source-generated validators to enforce rules automatically and keep your Minimal APIs rock-solid from day one. 🚀

## 🎥 Video Tutorial

Watch the step-by-step walkthrough on YouTube:



Replace YOUR_VIDEO_ID with your actual YouTube video ID.

## 🚀 Prerequisites

.NET 10 Preview 4 or later SDK

Visual Studio 2022 Preview (v17.9+) or Visual Studio Code with the latest C# extension

## 🛠️ Configuration

Pre-configured in this repo: source-generated validation and the Scalar testing UI are already set up. The steps below show how you would enable validation in a new project.

Enable source-generated validationIn your project file (.csproj), add:
```
<PropertyGroup>
  <InterceptorsNamespaces>$(InterceptorsNamespaces);Microsoft.AspNetCore.Http.Validation.Generated</InterceptorsNamespaces>
</PropertyGroup>
```

Register the validation services in Program.cs:
```
var builder = WebApplication.CreateBuilder(args);

// Enable validation for minimal APIs
builder.Services.AddValidation();

var app = builder.Build();
```
## 📦 Installation & Build

## Restore and build
```
dotnet restore
dotnet build
```
## 📂 Project Structure
```
Data/: Contains the OrderService implementation and sample data.

Models/: Holds the Order.cs class decorated with DataAnnotations for validation.
```
## 📝 API Docs & Interactive UI

The API documentation and built-in testing UI are preconfigured. To use:

Run the application (dotnet run or press F5 in Visual Studio).

Navigate to / to launch the Scalar interface.
```
app.MapOpenApi();
app.MapScalarApiReference("/", opt =>
{
    opt.Title = "Mock Server API";
    opt.Theme = ScalarTheme.Mars;
});
```
## 🔗 Links & Resources

[.NET DataAnnotations Documentation](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0)

[Minimal APIs in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-9.0)


