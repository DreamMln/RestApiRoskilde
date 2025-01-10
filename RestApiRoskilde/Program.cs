using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using RestApiRoskilde.Managers;
using System.Security.Claims;
using System.Web.Http;

//var config = new HttpConfiguration();
//config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling
//    = DateTimeZoneHandling.Local;
//config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add local DB
bool useSQL = true;
if (useSQL)
{
    var optionsBuilder = new DbContextOptionsBuilder<DBConnection>();
    optionsBuilder.UseSqlServer(Secret.ConnectionString);
    DBConnection context = new DBConnection(optionsBuilder.Options);
    builder.Services.AddSingleton(new BorgerDBManager(context));
}
//ellers brug mock data
else
{
    builder.Services.AddSingleton(new BorgerManager());
}

//cookie authentification
builder.Services.AddAuthentication(CookieAuthenticationDefaults
    .AuthenticationScheme)
    .AddCookie(cookieOptions => 
    { 
        cookieOptions.LoginPath = "/Login";
    });
//role authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("borger", policy =>
    policy.RequireClaim(ClaimTypes.Role, "user"));
}); 
//cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
//påsat
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
