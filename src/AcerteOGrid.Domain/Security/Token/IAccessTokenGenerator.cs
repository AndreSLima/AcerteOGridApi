using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Security.Token
{
    public interface IAccessTokenGenerator
    {
        string Generate(UserEntity userEntity);
    }
}
