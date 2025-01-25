﻿using AcerteOGrid.Domain.Repositories;

namespace AcerteOGrid.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AcerteOGridDbContex _dbContext;

        public UnitOfWork(AcerteOGridDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
