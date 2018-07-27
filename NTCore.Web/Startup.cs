using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NTCore.DataAccess;
using NTCore.DataAccess.Configuration;
using NTCore.DataAccess.TempIdentity;
using NTCore.DataModel;
using NTCore.Domain.Extensions;
using NTCore.Service.Context;
using NTCore.Service.Interface;
using NTCore.Service.ViewEngine;
using NTCore.Web.Extensions;
using OpenCqrs;
using OpenCqrs.Extensions;
using OpenCqrs.Store.EF.Extensions;
using OpenCqrs.Store.EF.MySql;
using System;
using System.IO;

namespace NTCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IContextService, ContextService>();

            var hostingEnvironment = services.BuildServiceProvider().GetService<IHostingEnvironment>();

            services.AddOptions();
            services.AddHttpContextAccessor();

            services.AddOpenCqrs().AddMySqlProvider(Configuration);

            services.Configure<NTCore.DataAccess.Configuration.Data>(c =>
            {
                c.Provider = (NTCore.DataAccess.Configuration.DataProvider)Enum.Parse(
                    typeof(NTCore.DataAccess.Configuration.DataProvider),
                    Configuration.GetSection("Data")["Provider"]);
            });
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            //services.AddApplicationInsightsTelemetry(Configuration);
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });

            services.AddEntityFramework(Configuration);
            //services.AddTransient<IContextFactory, ContextFactory>();

            // TEMP
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("ConnectionString")));

            // TEMP
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });

            //var connection = Configuration.GetConnectionString("SqlServer");
            //services.AddEntityFrameworkSqlServer().AddDbContext<MainContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("NTCore.WebFront")));
            //var connection = Configuration.GetConnectionString("MySQL");
            //services.AddEntityFrameworkSqlServer().AddDbContext<NFDbContext>(options => options.UseMySQL(connection, b => b.MigrationsAssembly("NTCore.WebFront")));

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = Keys.AuthenticationScheme;
                    options.DefaultChallengeScheme = Keys.AuthenticationScheme;
                })
                .AddCookie(Keys.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = Keys.AuthenticationCookie;
                    options.Cookie.Path = "/";

                    var path = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auth-ticket-keys"));
                    options.DataProtectionProvider = DataProtectionProvider.Create(path);

                    options.LoginPath = "/passport/login";
                    options.LogoutPath = "/passport/logout";
                    options.AccessDeniedPath = "/passport/forbidden";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                });


            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(ValidationFilter));

            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});
            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new AutofacModule());
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            DataAccess.AppDbContext appDbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IDispatcher dispatcher)
        {
            loggerFactory.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            app.UseOpenCqrs().EnsureDomainDbCreated();
            appDbContext.Database.Migrate();

            app.EnsureIdentityCreated(userManager, roleManager);

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseTheme();



            app.AddRoutes();
            app.AddLocalisation();
        }
    }
}

