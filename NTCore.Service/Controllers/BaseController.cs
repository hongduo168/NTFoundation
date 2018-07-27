using Microsoft.AspNetCore.Mvc;
using NTCore.DataModel.Entities;
using NTCore.Service.Interface;

namespace NTCore.Service.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IContextService _contextService;

        protected BaseController(IContextService contextService)
        {
            _contextService = contextService;
        }

        public SiteInfo SiteInfo => _contextService.GetCurrentSiteInfo();
        public long SiteId => SiteInfo.Id;
    }

}
