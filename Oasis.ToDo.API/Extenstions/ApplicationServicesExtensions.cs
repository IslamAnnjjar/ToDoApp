using API.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oasis.ToDoAPP.API.Data;
using Oasis.ToDoAPP.API.Interfaces;
using Oasis.ToDoAPP.API.Services;

namespace Oasis.ToDoAPP.API.Extenstions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IToDoApiService, ToDoApiService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("ConnectionString"));
            });

            return services;
        }
    }
}
