using AutoMapper;
using BackUpSystem.Data;
using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Services.Auth;
using BackUpSystem.Services.Auth.Contracts;
using BackUpSystem.Services.Data;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Utils;
using BackUpSystem.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            this.RegisterData(services);
            this.RegisterServices(services);
            this.RegisterAuthentication(services);
            this.RegisterInfrastructure(services);
            this.RegisterUtilities(services);
        }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<BackUpSystemDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITwitterAccountRepository, TwitterAccountRepository>();
            services.AddTransient<ITweetRepository, TweetRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITwitterAccountService, TwitterAccountService>();
            services.AddTransient<ITweetService, TweetService>();

            services.AddTransient<ITwitterService, TwitterService>();
            services.AddSingleton<ITwitterCredentials, TwitterCredentials>();
            services.AddSingleton<IFacebookCredentials, FacebookCredentials>();
        }

        private void RegisterAuthentication(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var twitterCredentials = serviceProvider.GetService<ITwitterCredentials>();
            var facebookCredentials = serviceProvider.GetService<IFacebookCredentials>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BackUpSystemDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = twitterCredentials.ConsumerKey;
                twitterOptions.ConsumerSecret = twitterCredentials.ConsumerSecret;
            });

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = facebookCredentials.AppId;
                facebookOptions.AppSecret = facebookCredentials.AppSecret;
            });

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
        }

        private void RegisterInfrastructure(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper();
        }

        private void RegisterUtilities(IServiceCollection services)
        {
            services.AddTransient<IOAuthCreationService, OAuthCreationService>();
            services.AddTransient<IJsonObjectDeserializer, JsonDeserializerWrapper>();
            services.AddTransient<IDateTimeProvider, DateTimeWrapper>();
            services.AddScoped<IMappingProvider, AutoMapperWrapper>();
            services.AddTransient<IStreamReader, StreamReaderWrapper>();
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
            name: "areaRoute",
            template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
