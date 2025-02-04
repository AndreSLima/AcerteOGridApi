using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        Task<UserEntity> Get();
    }
}
