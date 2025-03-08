
// per la Clear Architecture creare 4 progetti
// API, Application, Domain, Persistence
// aggiungere i progetti alla soluzione (dotnet sln add NomeProgetto)
// aggiungere al progetto API il riferimento al progetto Application
// aggiungere al progetto Application il riferimento al progetto Domain e Persistence
// aggiungere al progetto Persistence il riferimento al progetto Domain

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
