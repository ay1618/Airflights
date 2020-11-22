using AirflightsDomain.Services;
using AirflightsDomain.Profiles;
using AirflightsDomain.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using AirflightsDomain.Models.Flight;

namespace AirflightsDomain
{
    public static class DomainInjectionsSetup
    {
        //extension method for adding domain injections
        public static void AddDomainInjections(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateFlightDTO>, CreateFlightValidator>();
            services.AddTransient<IValidator<UpdateFlightDelayDTO>, UpdateFlightDelayValidator>();
            services.AddTransient<IValidator<UpdateFlightDTO>, UpdateFlightValidator>();

            services.AddAutoMapper(typeof(FlightProfile));
            services.AddAutoMapper(typeof(DictProfile));
            services.AddAutoMapper(typeof(UserProfile));

            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<IDictService, DictService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
