using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace NTCore.Service.Security
{
    public interface ISecurityService
    {
        bool IsUserAuthorized(IPrincipal user, IEnumerable<string> roleNames);
    }
}
