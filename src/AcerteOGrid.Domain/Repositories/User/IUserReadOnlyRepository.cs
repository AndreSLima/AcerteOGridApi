﻿namespace AcerteOGrid.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistsActiveUserWithEmail(string email);
    }
}
