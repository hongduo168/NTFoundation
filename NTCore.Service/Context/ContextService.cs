using Microsoft.AspNetCore.Http;
using NTCore.DataModel.Entities;
using NTCore.Domain.Queries;
using NTCore.Service.Interface;
using OpenCqrs;
using System;

namespace NTCore.Service.Context
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IDispatcher _dispatcher;

        public ContextService(IHttpContextAccessor httpContextAccessor
            /*, IDispatcher dispatcher*/)
        {
            _httpContextAccessor = httpContextAccessor;
            //_dispatcher = dispatcher;

            //var a = _dispatcher.GetResultAsync<GetUserInfo, UserInfo>(new GetUserInfo { Id = 1 }).Result;
        }

        private const string SiteInfoKey = "APP|SiteInfo";
        private const string LanguageInfoKey = "APP|LanguageInfo";
        private const string ThemeInfoKey = "APP|ThemeInfo";
        private const string UserInfoKey = "APP|UserInfo";

        public SiteInfo GetCurrentSiteInfo()
        {
            return GetInfo(SiteInfoKey, () => new SiteInfo());
        }

        public void SetLanguageInfo(LanguageInfo languageInfo)
        {
            SetInfo(LanguageInfoKey, languageInfo);
        }

        public LanguageInfo GetCurrentLanguageInfo()
        {
            return GetInfo(LanguageInfoKey, () =>
            {
                return new LanguageInfo();
            });
        }

        public ThemeInfo GetCurrentThemeInfo()
        {
            return GetInfo(ThemeInfoKey, () =>
            {
                return new ThemeInfo();
            });
        }

        public UserInfo GetCurrentUserInfo()
        {
            throw new NotImplementedException();
        }

        private void SetInfo(string key, object data)
        {
            _httpContextAccessor.HttpContext.Items.Add(key, data);
        }

        private T GetInfo<T>(string key, Func<T> acquire)
        {
            if (_httpContextAccessor.HttpContext.Items[key] == null)
                _httpContextAccessor.HttpContext.Items.Add(key, acquire());

            return (T)_httpContextAccessor.HttpContext.Items[key];
        }
    }
}
