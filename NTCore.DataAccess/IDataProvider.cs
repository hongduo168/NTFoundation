using Microsoft.Extensions.DependencyInjection;
using NTCore.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.DataAccess
{
    public interface IDataProvider
    {
        DataProvider Provider { get; }
        IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString);
        AppDbContext CreateDbContext(string connectionString);
    }
}
