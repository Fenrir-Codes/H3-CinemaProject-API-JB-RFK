using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;
using H3_CinemaProjektAPI_JB_RFK.Repositories;
using H3_CinemaProjektAPI_JB_RFK.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3_CinemaProjektAPI_JB_RFK
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
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            //scopeing
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepositories, BookingRepositories>();
            services.AddScoped<IDirectorsService, DirectorsService>();
            services.AddScoped<IDirectorsRepositories, DirectorsRepositories>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<IHallRepositories, HallRepositories>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieRepositories, MovieRepositories>();
            services.AddScoped<IPaymentDetailsService, PaymentDetailsService>();
            services.AddScoped<IPaymentDeatailsRepositories, PaymentDetailsRepositories>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileRepositories, ProfileRepositories>();
            services.AddScoped<ISeatNumberService, SeatNumberService>();
            services.AddScoped<ISeatNumberRepositories, SeatNumberRepositories>();

            services.AddControllers();
            //services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "H3_CinemaProjektAPI_JB_RFK", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "H3_CinemaProjektAPI_JB_RFK v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
