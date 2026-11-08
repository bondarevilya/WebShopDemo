# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

The solution uses the new XML solution format (`WebShopDemo.slnx`) and targets .NET 10.

```bash
dotnet build WebShopDemo.slnx                 # build everything
dotnet run --project WebShopDemo              # MVC web app (main app)
dotnet run --project WebShopDemo.API          # Web API (OpenAPI doc at /openapi/v1.json in Development)
dotnet run --project WebShopDemo.Grpc         # gRPC service
```

EF Core migrations (Identity DB, SQL Server LocalDB) live in the `WebShopDemo` project:

```bash
dotnet ef database update --project WebShopDemo
dotnet ef migrations add <Name> --project WebShopDemo --output-dir Data/Migrations
```

There is no test project yet.

## Architecture

Four projects; the three hosts all reference `WebShopDemo.Core`:

- **WebShopDemo.Core**: class library with the business logic. `Contracts/` holds the service interfaces, `Services/` their implementations, and `Models/` the DTOs (with DataAnnotations validation attributes).
- **WebShopDemo**: the ASP.NET Core MVC app with ASP.NET Identity (Razor Pages UI) backed by `ApplicationDbContext` on SQL Server. Services from Core are registered in `Program.cs` (e.g. `AddScoped<IProductService, ProductService>()`).
- **WebShopDemo.API**: Web API host. It doesn't register Core services yet, and its `ProductController` is still a placeholder.
- **WebShopDemo.Grpc**: gRPC host. It only contains the template `Greeter` service so far.

### Product data comes from JSON, not the database

`ProductService` reads products from a JSON file. The path is in the `DataFiles:Products` config key (in `appsettings.json` of the *host* project), resolved relative to `AppContext.BaseDirectory`. The file itself is `WebShopDemo.Core/Data/Products.json`, copied to the output directory via the Core `.csproj`. Any host that uses `IProductService` needs `DataFiles:Products` in its own config. The DB holds only Identity tables.

Note: config says `Data/products.json` (lowercase) while the file is `Products.json`. This works on Windows but would break on a case-sensitive filesystem.

## Conventions

- XML doc comments (`/// <summary>`) are written on public types and members. The MVC project has `GenerateDocumentationFile` enabled, which writes `WebShopDocumentation.xml`.
- Constructor-injected parameters are named with a leading underscore (`_productService`) and assigned to camelCase private readonly fields.
