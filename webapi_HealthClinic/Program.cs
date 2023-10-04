
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using webapi.health.clinic.Utils;

namespace webapi_HealthClinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "JwtBearer";
                options.DefaultAuthenticateScheme = "JwtBearer";
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,

                        ValidateAudience = true,

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-clinica-chave-autenticacao-webapi")),

                        ClockSkew = TimeSpan.FromMinutes(8),

                        ValidIssuer = "HealthClinic_Manha",

                        ValidAudience = "HealthClinic_Manha",

                    };

                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API healthClinic",
                    Description = "API para gerenciamento de healthClinic",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHub Do Desenvolvedor",
                        Url = new Uri("https://github.com/RichardRichk")
                    },
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Value: Bearer TokenJWT ",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                    new string[] {}
                }
                });

            });

            

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}