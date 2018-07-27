using System;

namespace NTCore.DataAccess
{
    public interface IContextFactory
    {
        AppDbContext Create();
    }
}
