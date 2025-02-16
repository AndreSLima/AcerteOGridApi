using AcerteOGrid.Communication.Login;
using AcerteOGrid.Domain.Repositories.User;
using AcerteOGrid.Domain.Security.Cryptography;
using AcerteOGrid.Domain.Security.Token;
using AcerteOGrid.Exception.ExceptionsBase;

namespace AcerteOGrid.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public LoginService(IUserReadOnlyRepository repository, IPasswordEncripter passwordEncripter, IAccessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null || !user.UserConfirmed)
            {
                throw new UnauthorizedException("Não autorizado");
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

            if (!passwordMatch)
            {
                throw new InvalidLoginException();
            }

            return new LoginResponse
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
