using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Barberia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Barberia.Application.Repositories.IRepositories;
using Barberia.Application.Repositories;
using Barberia.Application.Mapper;


namespace Barberia.Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection Services, IConfiguration configuration)
        {
            // Add SQL Server 
            Services.AddDbContext<BarberiaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            Services.AddAutoMapper(typeof(MappingProfiler));
            
            return Services;
        }
    }
}
