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
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using backend.Persistence.Contexts;
using backend.Persistence.Repositories;
using backend.Domains.Repositories;
using backend.Domains.Services;
using backend.Services;

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

            services.AddCors(options =>{

                options.AddPolicy(name: "MyPolicy",
                    builder =>{
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    }
                );

            });

            services.AddDbContext<AppDbContext>(p=>p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project-Course.API", Version = "v1" });
            // });

            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            services.AddAuthentication(x=>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x=>{
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //precisa validar a chave
                    IssuerSigningKey = new SymmetricSecurityKey(key),//informamos que é uma chave simétrica.
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };

            });




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
            app.UseCors(x=> x.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
