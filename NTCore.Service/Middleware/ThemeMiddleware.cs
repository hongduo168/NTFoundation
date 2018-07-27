using Microsoft.AspNetCore.Http;
using NTCore.Service.Interface;
using NTCore.Service.ViewEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTCore.Service.Middleware
{
    public class ThemeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IContextService _contextService;

        public ThemeMiddleware(RequestDelegate next,
            IContextService contextService)
        {
            _next = next;
            _contextService = contextService;
        }

        public Task Invoke(HttpContext context)
        {
            var folder = _contextService.GetCurrentThemeInfo()?.Folder;
            context.Request.HttpContext.Items[ViewLocationExpander.ThemeKey] = folder ?? "Default";
            return _next(context);
        }
    }

}
