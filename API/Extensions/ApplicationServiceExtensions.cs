using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt =>
             {
                 opt.AddPolicy("CorsPolicy", policy =>
                 {
                     policy
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .WithOrigins("http://localhost:3000")
                         .WithOrigins("http://localhost:3001");
                 }
                 );
             });
            return services;
        }
    }
}
