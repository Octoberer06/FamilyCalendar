//using FamilyCalendar.Endpoints; // Переписывание Endpoints
using FamilyCalendar.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FamilyCalendar.Extensions
{
    public static class ApiExtensions
    {
        // Переписывание Endpoints
        //public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        //{
        //    app.MapUsersEndpoints();
        //}

        public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddSingleton<JwtOptions>(jwtOptions);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false, // Валидация издетеля
                        ValidateAudience = false, // Валидация получателя
                        ValidateLifetime = true, // Валидация по времени - да (у нас там стоить время жизни токена 12 ч)
                        ValidateIssuerSigningKey= true, // Валидация секретного ключа который был указан в appsettings.json
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)) // (!) указывает на использование оператора Null-conditional, чтобы обрабатывать случай, когда jwtOptions может быть равно null.
                    };

                    // код выше попробует провалидировать токен из header`ов, а мы будем это делать из cookies (код ниже)

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["justCookie"]; // ключ для cookies из UseraEndpoints
                            return Task.CompletedTask; // 
                        }
                    };
                });

            services.AddAuthorization();
        }
    }
}
