namespace AcerteOGrid.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
