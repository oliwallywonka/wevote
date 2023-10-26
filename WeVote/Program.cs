using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WeVote.Providers;
using WeVote.Repositories;
using WeVote.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ADD DB CONTEXT
builder.Services.AddDbContext<EFContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WevoteConnection"));
});

// REPOSITORIES
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();

// SERVICES
builder.Services.AddScoped<IVisitService, VisitService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EFContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "ClientApp/dist")),
    RequestPath = ""
});

app.MapGet("/", () =>
{
    return Results.Redirect("/index.html");
});

app.Run();
