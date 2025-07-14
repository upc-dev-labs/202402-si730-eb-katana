using eb4364u20201e843.API.MRP.Application.Internal.CommandServices;
using eb4364u20201e843.API.MRP.Application.Internal.OutboundServices.ACL;
using eb4364u20201e843.API.MRP.Domain.Repositories;
using eb4364u20201e843.API.MRP.Domain.Services;
using eb4364u20201e843.API.MRP.Infrastructure.Persistence.EFC.Repositories;
using eb4364u20201e843.API.SCM.Application.ACL;
using eb4364u20201e843.API.SCM.Application.Internal.CommandServices;
using eb4364u20201e843.API.SCM.Application.Internal.QueryServices;
using eb4364u20201e843.API.SCM.Domain.Repositories;
using eb4364u20201e843.API.SCM.Domain.Services;
using eb4364u20201e843.API.SCM.Infrastructure.Configuration;
using eb4364u20201e843.API.SCM.Infrastructure.Persistence.EFC.Repositories;
using eb4364u20201e843.API.SCM.Interfaces.ACL;
using eb4364u20201e843.API.Shared.Domain.Repositories;
using eb4364u20201e843.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb4364u20201e843.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Configuration for Routing
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new InvalidOperationException("Connection string is null");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    }
});

// Configure Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Katana Manufacturing Platform API",
        Version = "v1",
        Description = "Backend RESTful API for Katana Manufacturing",
        TermsOfService = new Uri("https://katanamrp.com/service-terms"),
        Contact = new OpenApiContact
        {
            Name = "Katana Manufacturing",
            Email = "support@katanamrp.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache-2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });
});

// Dependency Injection Configuration

// Shared Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Dependency Injection for SCM Bounded Context
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IPartCommandService, PartCommandService>();
builder.Services.AddScoped<IPartQueryService, PartQueryService>();
builder.Services.AddScoped<IScmContextFacade, ScmContextFacade>();

// Dependency Injection for MRP Bounded Context
builder.Services.AddScoped<ExternalScmService>();
builder.Services.AddScoped<IBillOfMaterialsItemRepository, BillOfMaterialsItemRepository>();
builder.Services.AddScoped<IBillOfMaterialsItemCommandService, BillOfMaterialsItemCommandService>();

// Dependency for appsettings.json
// builder.Services.Configure<CapacityThresholdsOptions>(
//     builder.Configuration.GetSection("CapacityThresholds"));

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS Redirection
app.UseHttpsRedirection();

// Authorization
// app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();