﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Marvin.IDP.Entities;
using Marvin.IDP.Services;
using IdentityServer4;

namespace Marvin.IDP
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:marvinUserDBConnectionString"];
            services.AddDbContext<MarvinUserContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IMarvinUserRepository, MarvinUserRepository>();

            services.AddMvc();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddMarvinUserStore()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory, MarvinUserContext marvinUserContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            marvinUserContext.Database.Migrate();
            marvinUserContext.EnsureSeedDataForContext();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "idsrv.2FA",
                AutomaticAuthenticate = false,
                AutomaticChallenge = false
            });

            app.UseIdentityServer();

            app.UseFacebookAuthentication(new FacebookOptions
            {
                AuthenticationScheme = "Facebook",
                DisplayName = "Facebook",
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                AppId = "1570475679676847",
                AppSecret = "5b9f4bca5da29e234b706040aca883d3"
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
