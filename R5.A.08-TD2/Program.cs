using Microsoft.EntityFrameworkCore;
using R5.A._08_TD2.Models;
using R5.A._08_TD2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Connexion Entity Framework à PostgreSQL
builder.Services.AddDbContext<R508Context>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IMarqueRepository, MarqueRepository>();
builder.Services.AddScoped<ITypeProduitRepository, TypeProduitRepository>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();