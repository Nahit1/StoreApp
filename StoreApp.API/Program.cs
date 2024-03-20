using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StoreApp.Application;
using StoreApp.Domain.Entities;
using StoreApp.Persistance;
using StoreApp.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("StoreApp.Application"))
);

//builder.Services.AddStoreAppApplication(builder.Configuration);
builder.Services.AddStoreAppPersistance(builder.Configuration);
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])
            )
        };
    });

var app = builder.Build();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<StoreAppDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

await context.Database.MigrateAsync();
await DbInitializer.InitDb(context, userManager);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
