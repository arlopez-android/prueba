using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello Sexy Fat!");

app.MapGet("/dbconection", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok($"Base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();