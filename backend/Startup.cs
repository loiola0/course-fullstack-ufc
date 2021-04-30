using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using backend.Persistence.Contexts;
using backend.Persistence.Repositories;
using backend.Domains.Repositories;
using backend.Domains.Services;
using backend.Services;
using backend.Domains.Repositories;
using backend.Persistence.Repositories;
namespace backend
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

            services.AddDbContext<AppDbContext>(p=>p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project-Course.API", Version = "v1" });
            // });


            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<ICompanyService,CompanyService>();
             
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductService,ProductService>();

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserService,UserService>();
             
            services.AddScoped<IPurchaseRepository,PurchaseRepository>();
            services.AddScoped<IPurchaseService,PurchaseService>();

            services.AddScoped<ICartRepository,CartRepository>();
            services.AddScoped<ICartService,CartService>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
             
             
            services.AddAutoMapper(typeof(Startup));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
