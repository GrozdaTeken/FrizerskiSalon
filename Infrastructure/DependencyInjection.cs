﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Domain.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString));

            services.AddScoped<IRezervacijaRepository, RezervacijaRepository>();
            services.AddScoped<IFrizerRepository, FrizerRepository>();
            services.AddScoped<IBlacklistRepository, BlacklistRepository>();
            services.AddScoped<IGodisnjiRepository, GodisnjiRepository>();
            services.AddScoped<IRezervacijaRepository, RezervacijaRepository>();
            services.AddScoped<IMessageQueueRepository, MessageQueueRepository>();
<<<<<<< HEAD
            services.AddScoped<ISmenaRepository, SmenaRepository>();
=======
>>>>>>> 80e5097f761c6ae6a8f55b89dee82a16fdfcb46d

            return services;
        }
    }
}
