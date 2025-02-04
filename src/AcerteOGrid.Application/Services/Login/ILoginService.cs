using AcerteOGrid.Communication.Login;

namespace AcerteOGrid.Application.Services.Login
{
    public interface ILoginService
    {
        Task<LoginResponseJson> Execute(LoginRequestJSon request);
    }
}
