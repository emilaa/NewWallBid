using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WallBid.AdminPanel.Middlewares;
using WallBid.Business;
using WallBid.Data;
using WallBid.Data.Persistences;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Middlewares;
using WallBid.Infrastructure.Services.Abstracts;
using WallBid.Infrastructure.Services.Concrates;

namespace WallBid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "E-Services-MN",
                    Version = "v1"
                });
                c.EnableAnnotations();
                c.CustomSchemaIds(type => type.FullName);
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            AppDbServiceInjection.InstallAppDbServices(builder.Services, builder.Configuration);

            builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(IBusinessReferance).Assembly);
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>()
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();

            builder.Services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidIssuer = builder.Configuration["Jwt:Issuer"],
                   ValidAudience = builder.Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
               };
           });

            builder.Services.AddCors(m => m.AddPolicy("corspolicy", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corspolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGlobalErrorHandling();

            app.UseMiddleware<XssSanitizationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
