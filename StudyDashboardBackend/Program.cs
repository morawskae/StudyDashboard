using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using StudyDashboardBackend.Data;
using DotNetEnv;
using StudyDashboardBackend.Interfaces;
using StudyDashboardBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters= new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer= builder.Configuration["AppSettings:Issuer"],
        ValidateAudience=true,
        ValidAudience=builder.Configuration["AppSettings:Audience"],
        ValidateLifetime=true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
            ValidateIssuerSigningKey=true,
    };
});
builder.Services.AddControllers();
builder.Services.AddDbContext<StudyDashboardDbContext>(options=>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddOpenApi();
builder.Services.AddScoped<IAuthService,AuthService>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

