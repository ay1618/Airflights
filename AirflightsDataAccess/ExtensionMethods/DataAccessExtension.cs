using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.ExtensionMethods
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
