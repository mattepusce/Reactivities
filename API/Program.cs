
// per la Clean Architecture creare 4 progetti
// API,
// Application,
// Domain (entità),
// Persistence (dbContext)

// aggiungere i progetti alla soluzione (dotnet sln add NomeProgetto)
// aggiungere al progetto API il riferimento al progetto Application
// aggiungere al progetto Application il riferimento al progetto Domain e Persistence
// aggiungere al progetto Persistence il riferimento al progetto Domain

using Application.Activities.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Persistence.AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// abilita il CORS, ovvero permet di fare richieste da un dominio diverso da quello del server
builder.Services.AddCors();

// aggiunge MediatR per la gestione delle richieste
builder.Services.AddMediatR(
    x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>()
);

var app = builder.Build();

// abilita il CORS per tutti i metodi e header, e per i domini specificati
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:3000", "https://localhost:3000")
);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

// using serve per liberare la memoria una volta usato il servizio
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    // applica le migrazioni e semina i dati
    var context = services.GetRequiredService<Persistence.AppDbContext>();
    await context.Database.MigrateAsync();
    await Persistence.DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
