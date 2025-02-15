
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JWT_BlogProjesi
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
            builder.Services.AddSwaggerGen();

            //token için yazýlan aþaðý kýsým

            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = "http://localhost",
            //        ValidateAudience = "http://localhost",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mvcblogprojesi")),
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero

            //    };

            //});








            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
