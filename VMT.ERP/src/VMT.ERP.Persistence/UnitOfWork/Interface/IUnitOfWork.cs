namespace VMT.ERP.Persistence.UnitOfWork.Interface;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}