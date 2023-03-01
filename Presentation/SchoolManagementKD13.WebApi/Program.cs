using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementKD13.Application.Enums;
using SchoolManagementKD13.Application.IRepositories;
using SchoolManagementKD13.Infrastructure;
using SchoolManagementKD13.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//ServiceRegistration of Persistance
builder.Services.AddPersistanceServices();

//ServiceRegistration of Application
builder.Services.AddApplicationServices();

//ServiceRegistration of Infrastcture
builder.Services.AddInfrastructureServices();

//ServiceRegistration of Infrastructure // Buradan hangi servisi inject edersem o file service ile çalýþýyor olacaðým.
builder.Services.AddFileService(FileServiceType.Local);


//tüm originlere, tüm headlerlara ve tüm metotlara izin verdik.
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("https://localhost:7051").AllowAnyHeader().AllowAnyMethod()));

//Token oluþturma.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerRequired", policy => policy.RequireClaim("role", "Manager"));
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//wwwroot kullanýmý için;
app.UseStaticFiles();

//Cors
app.UseCors();

app.UseHttpsRedirection();

//Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
