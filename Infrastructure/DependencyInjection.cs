using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Domain.Interfaces;
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

            return services;
        }
    }
}
