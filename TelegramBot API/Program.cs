
using Microsoft.EntityFrameworkCore;
using Data_Access;
using Models.UserModels;
using Repositories.UserRepository;
using Services.UserServices;
using Services.JwtServices;
using ServicesLayer.Services.TelegramService;

namespace TelegramBot_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddDbContext<TbotDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("SqlConnection")));

            builder.Services.AddScoped<IUserRepository<Users>, UserRepository<Users>>();

            builder.Services.AddScoped(typeof(IUserRepository<>),typeof(UserRepository<>));

            builder.Services.AddScoped<IJwtServices, JwtServices>();

            builder.Services.AddScoped<IUserServices, UserServices>();

            builder.Services.AddSingleton<TelegramUpdateService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
