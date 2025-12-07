using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using projCSharp.Application.Interfaces;
using projCSharp.Application.Services;
using projCSharp.Domain.Interfaces.Repositories;
using projCSharp.Infrastructure.Extensions;
using projCSharp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database dependency injection:
builder.Services.AddInfrastructure(builder.Configuration);

// AutoMaper:
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Repositories and Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// ----------------------------------------------------------------
// JWT
// var key = builder.Configuration["Jwt:Key"];
// var issuer =  builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(options =>
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
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// ---------------------------------------------------------------




// ------------------------------------------------------
// Button of AUTHORIZE
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "projCSharp API", Version = "v1" });

    // Set autorización with JWT
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese su token JWT en el campo. Ejemplo: Bearer eyJhbGci..."
    });

    c.AddSecurityRequirement(new()
    {
        {
            new()
            {
                Reference = new()
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// -------------------------------------------------------------------

// builder.Services.AddAuthorization();


// ------------------------------------------------------
// CORS: Allows any origin in development environment.
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// -------------------------------------------------------------------
//deploy
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Catalog API v1");
        c.RoutePrefix = string.Empty;
    });
}

// -------------------------------------------------------------------
// // Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("DevCorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthentication(); // <--- important: auth before of authorization
app.UseAuthorization();

app.MapControllers();

app.Run();

