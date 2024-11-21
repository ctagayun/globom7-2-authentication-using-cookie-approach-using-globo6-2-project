using Api.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => 
    {
        o.Cookie.Name = "__Host-spa";
        o.Cookie.SameSite = SameSiteMode.Strict;
        o.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization(o => 
    o.AddPolicy("admin", p => p.RequireClaim("role", "Admin"))
);

//add the HouseDbContext to the dependency injection container
//I will be registering it with a scope of "Scope" which means a new instance
//will be created for each request that the API will receive.
//Because of that I am turning off a feature of database context that
//tracks each entity instance for property changes. It is more performant
//this way
builder.Services.AddDbContext<HouseDbContext>(o => 
    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<IHouseRepository, HouseRepository>();
//builder.Services.AddScoped<IBidRepository, BidRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles(); //Added - serves the content of wwwroot
app.UseAuthentication();

//Comment out because we are not allowing to call the app cross site
//allow everything from localhost:3000
//app.UseCors(p => p.WithOrigins("http://localhost:3000")
// .AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.UseHttpsRedirection();
app.MapHouseEndpoints();
app.MapBidEndpoints();
app.UseRouting();
app.UseAuthorization();
app.MapFallbackToFile("index.html"); //*index.html is the entrypoint of out React application
  //*if no endpoint match we tell it to fall back to index.html 
  //*we defined endpoints for Swagger (app.UseSwaggerUI) and 
  //*the API app.MapHouseEndpoints and  app.MapBidEndpoints();


app.Run();

