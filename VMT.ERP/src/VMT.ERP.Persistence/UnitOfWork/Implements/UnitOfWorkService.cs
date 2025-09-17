using VMT.ERP.Persistence.Database;
using VMT.ERP.Persistence.UnitOfWork.Interface;

namespace VMT.ERP.Persistence.UnitOfWork.Implements
{
    public class UnitOfWorkService(BaseErpContext _context) : IUnitOfWork
    {
        private readonly BaseErpContext context = _context;

        public async Task<int> CommitAsync() => await context.SaveChangesAsync();

        public void Dispose() => context.Dispose();
    }
}