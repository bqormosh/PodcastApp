using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PodcastApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastApp.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {

            services.AddTransient<IPodcastRepository, PodcastRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
           
            services.AddDbContext<ApplicationDbContext>(opt => opt
                .UseSqlServer(connectionString));

            return services;
        }
    }
}
