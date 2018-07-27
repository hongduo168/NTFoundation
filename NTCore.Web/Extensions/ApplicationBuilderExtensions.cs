using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NTCore.DataAccess;
using NTCore.DataAccess.TempIdentity;
using NTCore.DataModel.Entities;
using NTCore.Service.Middleware;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NTCore.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder EnsureDbCreated(this IApplicationBuilder app)
        {
            var dbContext = app.ApplicationServices.GetRequiredService<AppDbContext>();

            dbContext.Database.Migrate();

            return app;
        }

        public static IApplicationBuilder EnsureIdentityCreated(this IApplicationBuilder app, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //var userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            //var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<ApplicationRole>>();

            return app;
        }


        public static IApplicationBuilder AddLocalisation(this IApplicationBuilder app
            )
        {
            var supportedCultures = new List<CultureInfo>();
            RequestCulture defaultRequestCulture;

            IEnumerable<LanguageInfo> languages = new List<LanguageInfo>();
            try
            {
                foreach (var language in languages)
                    supportedCultures.Add(new CultureInfo(language.CultureName));

                defaultRequestCulture = new RequestCulture(supportedCultures[0].Name);
            }
            catch (Exception)
            {
                supportedCultures.Add(new CultureInfo("en"));
                defaultRequestCulture = new RequestCulture("en");
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = defaultRequestCulture,
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            return app;
        }

        public static IApplicationBuilder AddRoutes(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //routes.Routes.Add(new PageSlugRoute(routes.DefaultHandler));

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }

        public static IApplicationBuilder UseTheme(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ThemeMiddleware>();
        }

    }


}
