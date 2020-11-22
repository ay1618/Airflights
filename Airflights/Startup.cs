using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airflights.Attributes;
using Airflights.Middlewares;
using AirflightsDataAccess;
using AirflightsDataAccess.ExtensionMethods;
using AirflightsDataAccess.Repositories;
using AirflightsDomain;
using AirflightsDomain.Models.Flight;
using AirflightsDomain.Services;
using AirflightsDomain.Services.Implementations;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;

namespace Airflights
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt => 
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IValidator<CreateFlightDTO>, CreateFlightValidator>();

            services.AddDataAccessContext(Configuration["Db:ConnectionString"]);
            services.AddAutoMapper(typeof(AirflightsDataAccess.Profiles.FlightProfile));
            services.AddAutoMapper(typeof(AirflightsDataAccess.Profiles.DictProfile));
            services.AddAutoMapper(typeof(AirflightsDataAccess.Profiles.UserProfile));

            //add injections from Domain 
            services.AddDomainInjections();

            //add injection from DataAccess
            services.AddDataAccessInjections();

            services.AddHttpContextAccessor();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Airflights AirAstana",
                    Description = "test task",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Alisher Yessenkozha",
                        Email = "alisher1.618@gmail.com"
                    }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Airflights.xml");
                options.IncludeXmlComments(xmlPath);
            });

            //services.AddMvc(opt =>
            //{
            //    opt.Filters.Add(typeof(ValidatorActionFilter));
            //})
            //.AddFluentValidation(fvc =>
            //    fvc.RegisterValidatorsFromAssemblyContaining<Startup>()
            // );


            var key = Encoding.ASCII.GetBytes(Configuration["authSettings:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<RequestResponseLoggerMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "AirflightsAPI V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
