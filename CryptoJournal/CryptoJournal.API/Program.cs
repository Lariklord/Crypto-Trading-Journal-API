using CryptoJournal.Core.Interfaces.Repositories;
using CryptoJournal.Core.Interfaces.Services;
using CryptoJournal.Infrastructure.Database;
using CryptoJournal.Infrastructure.Mappings;
using CryptoJournal.Infrastructure.Repositories;
using CryptoJournal.Infrastructure.Services;
using CryptoJournal.Infrastructure.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Crypto Journal API",
        Contact = new OpenApiContact
        {
            Name = "Lariklord",
            Email = "vladklunduk8@gmail.com"
        }
    });
});

builder.Services.AddDbContext<TradingDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("CryptoJournal.Infrastructure")
));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasherService>();
builder.Services.AddTransient<ITraderRepository, TraderRepository>();
builder.Services.AddTransient<ITraderService, TraderService>();

builder.Services.AddAutoMapper(cnf =>
{
    cnf.AddProfile<MappingProfile>();
});
builder.Services.AddValidatorsFromAssemblyContaining<TraderUpdateDTOValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<TraderRegisterDTOValidator>();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapControllers();


app.Run();
