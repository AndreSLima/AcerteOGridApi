using AcerteOGrid.Communication.Login;

namespace AcerteOGrid.Application.Services.Login
{
    public interface ILoginService
    {
        Task<LoginResponse> Execute(LoginRequest request);
    }
}
