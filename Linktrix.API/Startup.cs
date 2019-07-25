using AutoMapper;
using Linktrix.API.Domain.Repositories;
using Linktrix.API.Domain.Service;
using Linktrix.API.Persistence.Contexts;
using Linktrix.API.Persistence.Repositories;
using Linktrix.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Linktrix.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LinktrixDb")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerTransactionRepository, CustomerTransactionRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerTransactionService, CustomerTransactionService>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
