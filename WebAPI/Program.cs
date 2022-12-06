using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.AutoFac;
using Core.DependencyResolvers;
using Core.Utilities.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


// Add services to the container.
/*
#region Brand
builder.Services.AddSingleton<IBrandService, BrandManager>();
builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
#endregion
#region Car
builder.Services.AddSingleton<ICarService, CarManager>();
builder.Services.AddSingleton<ICarDal, EfCarDal>();
#endregion
#region Color
builder.Services.AddSingleton<IColorService, ColorManager>();
builder.Services.AddSingleton<IColorDal, EfColorDal>();
#endregion
#region Customer
builder.Services.AddSingleton<ICustomerService, CustomerManager>();
builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();
#endregion
#region Rental
builder.Services.AddSingleton<IRentalService, RentalManager>();
builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
#endregion
#region User
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();
#endregion
*/

builder.Services.AddControllers();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


builder.Services.AddDependencyResolvers(new ICoreModule[] {
    new CoreModule() });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4201").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
