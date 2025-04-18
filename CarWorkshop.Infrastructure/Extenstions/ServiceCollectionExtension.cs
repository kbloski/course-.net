﻿using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Presistance;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Extenstions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(
                 configuration.GetConnectionString("CarWorkshopConnectionString")
                )
            );

            services.AddScoped<CarWorkshopSeeder>();
            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
        }
    }
}
