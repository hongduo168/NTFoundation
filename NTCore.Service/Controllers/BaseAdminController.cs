using NTCore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.Service.Controllers
{
    public abstract class BaseAdminController : BaseController
    {
        protected BaseAdminController(IContextService contextService)
            : base(contextService)
        {
        }
    }


}
