using AcerteOGrid.Communication;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Exception.ExceptionsBase;
using AcerteOGrid.Exception;

namespace AcerteOGrid.Application.Services
{
    public abstract class ServiceBase<BaseRequestJson> where BaseRequestJson : ABaseRequestJson
    {
        protected virtual void Validate(BaseRequestJson request, UserEntity user)
        {
            if (!user.UserTypeEntity.Maintenance)
                throw new UnauthorizedException(ResourceErrorMessages.UNAUTHORIZED);
        }
    }
}
