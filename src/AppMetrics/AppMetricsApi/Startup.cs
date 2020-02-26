using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMetrics.Application.Customers;
using AppMetrics.Application.Orders;
using AppMetrics.DAL;
using AppMetrics.Infrastructure;
using AppMetrics.Infrastructure.Contracts;
using AppMetrics.Infrastructure.Middlewares;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppMetricsApi
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
            services.AddMetrics();

            services.AddControllers();
            services.AddSwagger();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["Database:ConnectionString"]);
            });

            services.AddAutoMapper(typeof(ICustomerService).Assembly, typeof(ExceptionContract).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ErrorMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
