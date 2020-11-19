using AirflightsDomain.Services;
using AirflightsDomain.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain
{
    public static class DomainInjectionsSetup
    {
        //extension method for adding domain injections
        public static void AddDomainInjections(this IServiceCollection services)
        {
            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<IDictService, DictService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
