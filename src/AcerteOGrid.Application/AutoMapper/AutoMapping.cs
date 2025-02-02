using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Domain.Entities;
using AutoMapper;

namespace AcerteOGrid.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<PilotInsertRequestJson, PilotEntity>();
            CreateMap<UserInsertRequestJson, UserEntity>()
                .ForMember(userEntity => userEntity.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<PilotEntity, PilotResponseJson>();
            //.ForMember(dest => dest.Name, config=> config.MapFrom(source=> source.Name));
        }
    }
}
