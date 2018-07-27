using NTCore.DataAccess;
using NTCore.DataModel.Entities;
using NTCore.Domain.Queries;
using OpenCqrs.Queries;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NTCore.Domain.Handlers
{
    public class GetUserInfoQueryHandlerAsync : IQueryHandlerAsync<GetUserInfo, UserInfo>
    {
        private readonly IContextFactory _contextFactory;

        public GetUserInfoQueryHandlerAsync(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<UserInfo> RetrieveAsync(GetUserInfo query)
        {
            using (var context = _contextFactory.Create())
            {
                return context.User.FirstOrDefaultAsync(x => x.Id == query.Id);
            }
        }

    }
}
