using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderSystem.Commands;
using OrderSystem.Controllers;
using OrderSystem.EventPublisher;
using OrderSystem.Events;
using OrderSystem.Repository;

namespace OrderSystem
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<OrdersDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString")));
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<ICommand, CreateOrder>();
            services.AddScoped<IEvents, OrderEvents.OrderPlaced>();
            services.AddScoped<IOrderApplicationServices, OrderApplicationServices>();
            services.AddSingleton<IServiceBusEventPublisher, ServiceBusEventPublisher>(c => new ServiceBusEventPublisher(Configuration.GetConnectionString("ServiceBusConnectionString"), Configuration.GetValue<string>("TopicName")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
