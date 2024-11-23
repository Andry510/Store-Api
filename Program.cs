using Microsoft.EntityFrameworkCore;
using store.Repositories;
using store.Interfaces;
using store.Contexts;
using store.Services;
using System.Text.Json.Serialization;
using store.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
).AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter<Role>())
);
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

//Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IHashingService, HashingService>();

//Context
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MysqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
