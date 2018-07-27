using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace NTCore.Extensions.HttpContext
{
    /// <summary>
    /// HttpContext
    /// </summary>
    public static class CoreHttpContext
    {
        private static IHttpContextAccessor _contextAccessor;


        /// <summary>
        /// 
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;


        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
