using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BettleHubCsharp.Data;
using BettleHubCsharp.Models;
using Microsoft.AspNetCore.Identity;
using BettleHubCsharp.Middlewares;
using BettleHubCsharp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<JwtTokenService>();

// Configuración del servicio de contexto de base de datos
var connectionString = builder.Configuration.GetConnectionString("DataContext");
builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Configuración de Identity
builder.Services.AddIdentity<Biologo, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<IdentityContext>();

// Registro del servicio de IEmailSender
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3301", "https://localhost:8080", "https://localhost:5001")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE");
    });
});

// Configuración de los servicios de MVC
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Configuración de JWT
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

var app = builder.Build();

// Configuración específica del entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración para usar archivos estáticos
app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = ["inicioSesion.html"] });
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();
//Primero se tiene que hacer el authentication y luego el authorization
app.UseAuthentication();
app.UseAuthorization();
app.UseSlidingExpirationJwt();

app.UseCors();
app.MapControllers();
app.Run();