using AcerteOGrid.Domain.Repositories;

namespace AcerteOGrid.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AcerteOGridDbContext _dbContext;

        public UnitOfWork(AcerteOGridDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
