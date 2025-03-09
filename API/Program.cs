
// per la Clean Architecture creare 4 progetti
// API,
// Application,
// Domain (entità),
// Persistence (dbContext)

// aggiungere i progetti alla soluzione (dotnet sln add NomeProgetto)
// aggiungere al progetto API il riferimento al progetto Application
// aggiungere al progetto Application il riferimento al progetto Domain e Persistence
// aggiungere al progetto Persistence il riferimento al progetto Domain

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Persistence.AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
