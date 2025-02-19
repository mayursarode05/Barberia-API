using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Barberia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection Services, IConfiguration configuration)
        {
            // Add SQL Server 
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return Services;
        }
    }
}
