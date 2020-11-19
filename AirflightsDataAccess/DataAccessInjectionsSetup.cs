using AirflightsDataAccess.Repositories;
using AirflightsDomain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess
{
    //extension methods for DAL injections
    public static class DataAccessInjectionsSetup
    {
        public static void AddDataAccessInjections(this IServiceCollection services)
        {
            services.AddScoped<IFlightsRepository, FlightsSqlRepository>();
            services.AddScoped<IDictRepository, DictSqlRepository>();
            services.AddScoped<IUserRepository, UserSqlRepository>();
        }
    }
}
