using ConnectivityWithAngular.Data;
using ConnectivityWithAngular.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConnectContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB")));

builder.Services.AddTransient<IConnectRepository, ConnectRepository>();
//builder.Services.AddCors(option =>
//{
//    option.AddPolicy("AllowAngularApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:4200") // Angular uygulamasının çalıştığı URL
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
