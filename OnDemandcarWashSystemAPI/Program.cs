using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Repositorry;
using OnDemandcarWashSystemAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
});

// Dependency Injection Implemented
builder.Services.AddDbContext<CarWashContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddTransient<IPackage, PackageRepository>();
builder.Services.AddTransient<PackageService, PackageService>();

builder.Services.AddTransient<IAdmin, AdminRepository>();
builder.Services.AddTransient<AdminService, AdminService>();

builder.Services.AddTransient<ICar, CarRepository>();
builder.Services.AddTransient<CarService, CarService>();

builder.Services.AddScoped<IRepository<UserDetails, int>, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddScoped<IRegister<CreateUserDto, UserDetails>, RegisterRepository>();
builder.Services.AddScoped<RegisterService, RegisterService>();

builder.Services.AddScoped<IViewInvoice, ViewInvoiceRepository>();
builder.Services.AddScoped<ViewInvoiceService, ViewInvoiceService>();

builder.Services.AddScoped<IToken, TokenRepository>();

builder.Services.AddScoped<ILogin<Login, int>, LoginRepository>();
builder.Services.AddScoped<LoginService, LoginService>();

builder.Services.AddTransient<IAddress, AddressRepository>();
builder.Services.AddTransient<AddressService, AddressService>();

builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<OrderService, OrderService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
		ValidateIssuer = false,
		ValidateAudience = false,
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
	});
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// CORS Implementation
app.UseCors(options =>
{
	options.AllowAnyHeader();
	options.AllowAnyMethod();
	options.AllowAnyOrigin();
});

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();



/*using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnDemandcarWashSystemAPI.Data;
using OnDemandcarWashSystemAPI.DTOs;
using OnDemandcarWashSystemAPI.Interfaces;
using OnDemandcarWashSystemAPI.Models;
using OnDemandcarWashSystemAPI.Repositorry;
using OnDemandcarWashSystemAPI.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection Implemented
builder.Services.AddDbContext<CarWashContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddTransient<IPackage, PackageRepository>();
builder.Services.AddTransient<PackageService, PackageService>();

builder.Services.AddTransient<IAdmin, AdminRepository>();
builder.Services.AddTransient<AdminService, AdminService>();

builder.Services.AddTransient<ICar, CarRepository>();
builder.Services.AddTransient<CarService, CarService>();

builder.Services.AddScoped<IRepository<UserDetails, int>, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddScoped<IRegister<CreateUserDto, UserDetails>, RegisterRepository>();
builder.Services.AddScoped<RegisterService, RegisterService>();

builder.Services.AddScoped<IViewInvoice, ViewInvoiceRepository>();
builder.Services.AddScoped<ViewInvoiceService, ViewInvoiceService>();

builder.Services.AddScoped<IToken, TokenRepository>();

builder.Services.AddScoped<ILogin<Login, int>, LoginRepository>();
builder.Services.AddScoped<LoginService, LoginService>();

builder.Services.AddTransient<IAddress, AddressRepository>();
builder.Services.AddTransient<AddressService, AddressService>();

builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<OrderService, OrderService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
		ValidateIssuer = false,
		ValidateAudience = false,
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// CORS Implementation
app.UseCors(options =>
{
	options.AllowAnyHeader();
	options.AllowAnyMethod();
	options.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();*/