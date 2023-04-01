using System.Text;
using HotelListingInfrastructure.cs.Configurations;
using HotelListingInfrastructure.cs.Services;
using HotelManagement.Presistance.IoC;
using Hotelmanagment.Application.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(op =>
    {
        //With That code we can prevent an error For loop of relation Between tables
        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    ;
builder.Services.AddAuthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel Management", Version = "v1" }));

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", b =>
    {
        b.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

    });
});

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File(
        path: "logs\\log-.txt",
        outputTemplate: "{{timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}} [{{level:u3}}] {{message:lj}}{{NewLine}}{Exception}",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Information
    )

);

#region Authentication

//As You can see this section came from AppSetting.json file
var jwtSettings = builder.Configuration.GetSection("jwt");
//We create our variable in Environment (8 ;;
//never Put It On AppSetting
var key = Environment.GetEnvironmentVariable("KEY");

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //This Issuer name came from appSetting.json File
            ValidIssuer = jwtSettings.GetSection("Issuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        };
    });


builder.Services.AddScoped<IAuthManager, AuthManager>();

#endregion

builder.Services.ServicesConfigurationFrompresistance(builder.Configuration);
builder.Services.ServiceConfigurationFromApplication();
//builder.Services.JwtConfig(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
