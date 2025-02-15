using AcerteOGrid.Communication.User;

namespace AcerteOGrid.Application.Services.User
{
    public interface IUserInsertService
    {
        Task<UserResponseInsert> Execute(UserRequestInsert request);
    }
}
