using DemoWebAPI.Data;
using DemoWebAPI.Repositories;
using DemoWebAPI.Repositories.Interfaces;
using DemoWebAPI.Services;
using DemoWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));

// 3 méthodes de lifetime
// * scoped: envoie d'une instance par requête HTTP
// * Transient: envoie d'une instance par appel
// * Singleton: envoie de la même instance partout dans l'application

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
