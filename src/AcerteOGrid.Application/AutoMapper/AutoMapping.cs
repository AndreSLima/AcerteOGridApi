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
            UserMapping();
            PilotMapping();
        }

        private void UserMapping()
        {
            CreateMap<UserInsertRequestJson, UserEntity>()
                .ForMember(userEntity => userEntity.UserTypeEntityId, config => config.MapFrom(source => 2))
                .ForMember(userEntity => userEntity.Password, config => config.Ignore());
        }

        private void PilotMapping()
        {
            CreateMap<PilotEntity, PilotResponseJson>();

            CreateMap<PilotInsertRequestJson, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => (int)source.GenderType == 1));

            CreateMap<PilotUpdateRequestJson, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => (int)source.GenderType == 1));
        }
    }
}
