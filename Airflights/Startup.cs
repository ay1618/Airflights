using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AirflightsDataAccess.ExtensionMethods;
using AirflightsDataAccess.Repositories;
using AirflightsDomain;
using AirflightsDomain.Services;
using AirflightsDomain.Services.Implementations;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

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
            services.AddControllers();

            services.AddDataAccessLayer(Configuration["Db:ConnectionString"]);
            services.AddAutoMapper(typeof(AirflightsDataAccess.Profiles.FlightProfile));
            services.AddAutoMapper(typeof(AirflightsDataAccess.Profiles.DictProfile));

            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<IDictService, DictService>();
            services.AddScoped<IFlightsRepository, FlightsSqlRepository>();
            services.AddScoped<IDictRepository, DictSqlRepository>();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

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
