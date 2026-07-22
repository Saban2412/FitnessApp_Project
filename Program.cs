using System.Runtime.CompilerServices;
using FitnessApp.Data;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//di za dbcontext
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API v1");
});

app.UseHttpsRedirection();

//dataTest

app.MapPost("/data-test",async (ApplicationDbContext _db) =>
{
    var trener = new Trener{
        Ime = "Test-Trener", 
        Prezime = "Test-Prezime", 
        DatumRodjenja = new DateTime(2000,1,1),
        Certifikat = "TEST-001"
        };

    _db.Treneri.Add(trener);
    await _db.SaveChangesAsync();
    return Results.Ok(trener);
});

app.MapPost("/client-test",async (ApplicationDbContext _db) =>
{
    var klijent = new Klijent
    {
      Ime = "Test-Klijent",
      Prezime = "Test-Prezime",
      DatumRodjenja = new DateTime(2001,1,1),
      KilazaPocetna = 100,
      Visina = 190,
      TrenerId = 1  
    };

    _db.Klijenti.Add(klijent);
    await _db.SaveChangesAsync();
    return Results.Ok(klijent);
});

app.MapGet("/treneri/{id}", async (int id, ApplicationDbContext db) =>
{
    var trener = await db.Treneri
        .Include(t => t.Klijenti)
        .FirstOrDefaultAsync(t => t.Id == id);

    return trener is null
        ? Results.NotFound()
        : Results.Ok(trener);
});

app.Run();

