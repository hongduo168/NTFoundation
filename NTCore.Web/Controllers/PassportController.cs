using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using NTCore.DataModel;
using NTCore.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.Web.Controllers
{
    [AllowAnonymous]
    public class PassportController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Login(string returnUrl)
        {
            var claims = new ClaimsIdentity(Keys.AuthenticationScheme);
            claims.AddClaim(new Claim(ClaimTypes.Name, "username"));

            var user = new ClaimsPrincipal(claims);
            await HttpContext.SignInAsync(Keys.AuthenticationScheme, user, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
            });


            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = "/";
            }
            return Redirect(returnUrl);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(Keys.AuthenticationCookie);
            return Redirect("/");
        }

        [Authorize]
        public IActionResult forbidden()
        {
            return View();
        }

    }
}
