using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Angular.WebApiCore.SurveyApp.DataAccess.Context;
using Angular.WebApiCore.SurveyApp.DataAccess.Repositories;
using Angular.WebApiCore.SurveyApp.Models;
using Angular.WebApiCore.SurveyApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Angular.WebApiCore.SurveyApp.Configurations;
using Angular.WebApiCore.SurveyApp.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace Angular.WebApiCore.SurveyApp
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
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
                options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                if (options.SerializerSettings.ContractResolver != null)
                {
                    var CastResolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                    CastResolver.NamingStrategy = null;
                }
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
            services.AddDbContext<SurveyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SurveyDBConnection")));

            services.Configure<CsvFileConfig>(Configuration.GetSection("CsvFileConfig"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();            
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(ICsvDataReader), typeof(CsvDataReader));
            services.AddTransient<IDbInitialiser, DbInitialiser>();

            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }               
            
            app.Use(async (context, next) => 
            {
                await next();
                if(context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseCors(builder => 
                builder.AllowAnyHeader()
                       .AllowAnyMethod());

            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            InitializeDatabase(app);            

        }

        private void InitializeDatabase(IApplicationBuilder app)
        {            
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<SurveyContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<IDbInitialiser>().Seed();
            }                      
   
        }
    }
}
