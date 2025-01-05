﻿using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Ovde registrujemo sve servise i validatore specifične za Application sloj

            // Primer registracije servisa:
            // services.AddScoped<IRezervacijaService, RezervacijaService>();
            services.AddScoped<IFrizerService, FrizerService>();
            services.AddScoped<IBlacklistService, BlacklistService>();

            return services;
        }
    }
}
