using System;
using System.Threading;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);

        Task Commit();

        void Rollback();
    }
}