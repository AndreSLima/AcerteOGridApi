﻿using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace AcerteOGrid.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly AcerteOGridDbContext _dbcontext;

        public UserRepository(AcerteOGridDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> ExistsActiveUserWithEmail(string email)
        {
            return await _dbcontext.UserTable.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<UserEntity?> GetUserByEmail(string email)
        {
            return await _dbcontext.UserTable.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task Insert(UserEntity userEntity)
        {
            await _dbcontext.UserTable.AddAsync(userEntity);
        }
    }
}
