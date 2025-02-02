using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        Task Insert(UserEntity userEntity);
    }
}
