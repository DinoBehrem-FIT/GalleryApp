using GalleryApp.Repository.Context;
using GalleryApp.Repository.Repostiory;
using GalleryApp.Service.Helpers;
using GalleryApp.Service.Interfaces;
using GalleryApp.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.API.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GalleryApp.API", Version = "v1" });
            });

            services.AddDbContext<GalleryContext>(options => options.UseSqlServer(configuration.GetConnectionString("GalleryBase")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IExhibitionService, ExhibitionService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddCors();

            return services;
        }
    }
}
