using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace NTCore.Service.Security
{
    public class SecurityService : ISecurityService
    {
        public bool IsUserAuthorized(IPrincipal user, IEnumerable<string> roleNames)
        {
            if (user == null || roleNames == null || !roleNames.Any())
                return false;

            foreach (var role in roleNames)
            {

                if (user.IsInRole(role))
                    return true;
            }

            return false;
        }
    }


}
