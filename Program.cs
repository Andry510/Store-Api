
using Microsoft.EntityFrameworkCore;
using store.Interfaces;
using store.Contexts;
using store.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

//Context
builder.Services.AddDbContext<DataBaseContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("MysqlConnection"),
    new MySqlServerVersion(new Version(8,0,30))
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
