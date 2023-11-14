using HospitalCareSystem.BL;
using HospitalCareSystem.DAL;
using HospitalCareSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace HospitalSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion
          
            #region Database
            var connectionString = builder.Configuration.GetConnectionString("Hospital");
            builder.Services.AddDbContext<HospitalContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion
            #region Services

            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IDoctorManger, DoctorManger>();
            builder.Services.AddScoped<IIssueRepo, IssueRepo>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Asp Identity Before Auth
            builder.Services.AddIdentity<User,IdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5);
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<HospitalContext>();
            #endregion
            #region Authuntication
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "default";
                option.DefaultChallengeScheme = "default";
            })
                .AddJwtBearer("default",
                options =>
                {
                    var secretKey = builder.Configuration.GetValue<string>("SecretKey");
                    var keyInBytes = Encoding.ASCII.GetBytes(secretKey!);
                    var keySymetricSecKey = new SymmetricSecurityKey(keyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey= keySymetricSecKey,
                        ValidateIssuer=false,
                        ValidateAudience=false,
                    };
                });

            #endregion

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagerPolicy", policy =>
                policy.RequireClaim(ClaimTypes.Role, "Admin").RequireClaim("Departmentt", "Doctor"));

                options.AddPolicy("Data", policy => policy.RequireClaim(ClaimTypes.Role, "Doctor"));
            });
            var app = builder.Build();

            #region Default Enviroment
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #endregion

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}