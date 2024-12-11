using Innovaria.COMMON.Interfaces;
using Innovaria.DAL.Repositories.Lecturas;
using Innovaria.DAL.Repositories.NewFolder;
using Innovaria.DAL.Repositories.Properties;
using Innovaria.DAL.Repositories.Sensores;
using Innovaria.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
builder.Services.AddSwaggerGen(
                    setup =>
                    {
                        // Include 'SecurityScheme' to use JWT Authentication
                        var jwtSecurityScheme = new OpenApiSecurityScheme
                        {
                            Scheme = "bearer",
                            BearerFormat = "JWT",
                            Name = "JWT Authentication",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.Http,
                            Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                            Reference = new OpenApiReference
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme
                            }
                        };

                        setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                        setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });
                    });

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddTransient<ISensorRepository, SensorRepository>();
builder.Services.AddTransient<ILecturasRepository, LecturasRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapSwagger().RequireAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
