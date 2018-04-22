using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BackUpSystem.Data;
using BackUpSystem.Data.Models;
using BackUpSystem.Web.Services;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Auth;
using BackUpSystem.Utilities.Contracts;
using BackUpSytem.Services.Data.Contracts;
using BackUpSytem.Services.Data;
using BackUpSystem.Utils;

namespace BackUpSystem.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, 
            IHostingEnvironment hostingEnvironment)
        {
            this.Configuration = configuration;
            this.HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BackUpSystemDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BackUpSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Environment.GetEnvironmentVariable("ConsumerKey", EnvironmentVariableTarget.User);
                twitterOptions.ConsumerSecret = Environment.GetEnvironmentVariable("ConsumerSecret", EnvironmentVariableTarget.User);
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IOAuthCreationService, OAuthCreationService>();

            services.AddTransient<IStreamReader, StreamReaderWrapper>();
            services.AddTransient<IJsonObjectDeserializer, JsonDeserializerWrapper>();
            services.AddTransient<ITwitterService, TwitterService>();
            services.AddTransient<ITwitterCredentials, TwitterCredentials>();

            if (this.HostingEnvironment.IsDevelopment())
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
                    options.Lockout.MaxFailedAccessAttempts = 999;
                });
            }

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
