using AcerteOGrid.Communication;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Services.LoggedUser;

namespace AcerteOGrid.Application.Services
{
    public abstract class ServiceBase<BaseRequest, BaseResponse> where BaseRequest : ABaseRequest where BaseResponse : ABaseResponse
    {
        private readonly ILoggedUser _loggedUser;
        protected UserEntity? baseLoggedUser;

        public ServiceBase(ILoggedUser loggedUser)
        {
            _loggedUser = loggedUser;
        }

        private async Task<UserEntity> LoggedUserEntity()
        {
            baseLoggedUser = await _loggedUser.Get();

            return baseLoggedUser;
        }

        public virtual async Task Execute(BaseRequest request)
        {
            baseLoggedUser = await LoggedUserEntity();
        }

        protected bool UserAdmin()
        {
            if (baseLoggedUser is null)
                return false;

            return baseLoggedUser!.UserTypeEntity.Administrator;
        }

        protected bool UserMaintence()
        {
            if (baseLoggedUser is null)
                return false;

            return baseLoggedUser!.UserTypeEntity.Maintenance;
        }
    }
}
