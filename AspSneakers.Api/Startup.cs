using AspSneakers.Api.Core;
using AspSneakers.Api.Emails;
using AspSneakers.Api.Extensions;
using AspSneakers.Application.Emails;
using AspSneakers.Application.Logging;
using AspSneakers.Application.UseCases;
using AspSneakers.Application.UseCases.Commands;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Implementation;
using AspSneakers.Implementation.Emails;
using AspSneakers.Implementation.Logging;
using AspSneakers.Implementation.UseCases.Commands;
using AspSneakers.Implementation.UseCases.Queries.Ef;
using AspSneakers.Implementation.UseCases.UseCaseLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AspSneakers.Api
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

            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            
            services.AddApplicationUser();
            services.AddJwt(settings);
            services.AddUseCases();
            services.AddSneakersDbContext();

       
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x => new SmtpEmailSender(settings.EmailFrom, settings.EmailPassword));
            
 
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspSneakers.Api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspSneakers.Api v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
