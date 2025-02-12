using AcerteOGrid.Communication;
using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Enums;
using AutoMapper;

namespace AcerteOGrid.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BaseInsertRequestJson, BaseEntity>()
                .ForMember(baseEntity => baseEntity.DateInclusion, config => config.MapFrom(source => DateTime.Now));

            CreateMap<BaseUpdateRequestJson, BaseEntity>()
                .ForMember(baseEntity => baseEntity.DateChange, config => config.MapFrom(source => DateTime.Now));

            UserMapping();
            PilotMapping();
        }

        private void UserMapping()
        {
            CreateMap<UserInsertRequestJson, UserEntity>()
                .ForMember(userEntity => userEntity.UserTypeEntityId, config => config.MapFrom(source => 2))
                .ForMember(userEntity => userEntity.Password, config => config.Ignore())
                .IncludeBase<BaseInsertRequestJson, BaseEntity>();
        }

        private void PilotMapping()
        {
            CreateMap<PilotEntity, PilotResponseJson>();

            CreateMap<PilotInsertRequestJson, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => source.GenderType == GenderTypeEnum.Male))
                .IncludeBase<BaseInsertRequestJson, BaseEntity>();

            CreateMap<PilotUpdateRequestJson, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => source.GenderType == GenderTypeEnum.Male))
                .IncludeBase<BaseUpdateRequestJson, BaseEntity>();
        }
    }
}
