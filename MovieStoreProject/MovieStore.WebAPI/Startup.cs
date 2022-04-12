using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieStore.Business.Mapping;
using MovieStore.Business.Services;
using MovieStore.Business.Validation;
using MovieStore.Core.Abstract;
using MovieStore.Data.ContextConfiguration;
using MovieStore.Data.Repositories;
using MovieStore.Data.UnitOfWork;
using MovieStore.WebAPI.Authentication;
using MovieStore.WebAPI.Filter;
using MovieStore.WebAPI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //For use Autofac
            containerBuilder.RegisterModule(new RepoServiceModul());
        }

        public IConfiguration Configuration { get; }
        private readonly string key = "Bu benim uzun string key deðerim";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer( x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                       ValidateIssuer = false,
                       ValidateAudience = false,

                   };
               });

            services.AddSingleton<IJWTAuthenticationManager>(new JwtAuthenticationManager(key));

            services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()));
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieDtoValidator>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddDbContext<Context>
                (
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"),
                options => options.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name)
                ));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieStore", Version = "v1" });
            });
            services.AddMemoryCache();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStore.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
