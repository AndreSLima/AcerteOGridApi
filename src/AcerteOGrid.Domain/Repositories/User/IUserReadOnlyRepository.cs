using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistsActiveUserWithEmail(string email);
        Task<UserEntity?> GetUserByEmail(string email);
    }
}
