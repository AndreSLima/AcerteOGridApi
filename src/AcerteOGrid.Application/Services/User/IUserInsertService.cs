using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Communication.User.Response;

namespace AcerteOGrid.Application.Services.User
{
    public interface IUserInsertService
    {
        Task<UserInsertResponseJson> Execute(UserInsertRequestJson request);
    }
}
