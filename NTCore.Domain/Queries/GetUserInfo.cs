using OpenCqrs.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.Domain.Queries
{
    public class GetUserInfo : IQuery
    {
        public long Id { get; set; }

    }
}
