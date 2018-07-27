using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.DataModel;
using NTCore.DataModel.Entities;
using NTCore.Domain.Queries;
using NTCore.Service.Controllers;
using NTCore.Service.Interface;
using OpenCqrs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NTCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        private ILogger<ValuesController> logger;
        private AppDbContext dbContext;
        private IDistributedCache _memoryCache;


        public ValuesController(ILogger<ValuesController> logger, AppDbContext dbContext, IDistributedCache memoryCache, 
            IContextService contextService,
            IDispatcher dispatcher) : base(contextService)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this._memoryCache = memoryCache;

            var a = dispatcher.GetResultAsync<GetUserInfo, UserInfo>(new GetUserInfo { Id = 1 }).Result;
        }

        [AllowAnonymous]
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {


            var firstOrDefault = this.dbContext.User.FirstOrDefault();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "bob"), new Claim(ClaimTypes.Name, "bob222") }, Keys.AuthenticationScheme));
            await HttpContext.SignInAsync(Keys.AuthenticationScheme, user, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
            });

            var nameValue = User.FindFirst(ClaimTypes.Name)?.Value;

            var isAuth = User.Identity.IsAuthenticated;
            var name = User.Identity.Name;

            return new string[] { nameValue, isAuth.ToString() };
        }

        [Authorize]
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id, User user)
        {
            return "value" + id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class User
    {
        [Required]
        public string name { get; set; }
    }
}
