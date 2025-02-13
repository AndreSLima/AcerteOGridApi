using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        bool ExistsActiveUserWithEmail(string email);
        Task<UserEntity?> GetUserByEmail(string email);
    }
}
