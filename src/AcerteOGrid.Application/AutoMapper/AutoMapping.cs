using AcerteOGrid.Communication;
using AcerteOGrid.Communication.Pilot;
using AcerteOGrid.Communication.User;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Enums;
using AutoMapper;

namespace AcerteOGrid.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ABaseRequestInsert, BaseEntity>()
                .ForMember(baseEntity => baseEntity.DateInclusion, config => config.MapFrom(source => DateTime.Now));

            CreateMap<ABaseRequestUpdate, BaseEntity>()
                .ForMember(baseEntity => baseEntity.DateChange, config => config.MapFrom(source => DateTime.Now));

            UserMapping();
            PilotMapping();
        }

        private void UserMapping()
        {
            CreateMap<UserRequestInsert, UserEntity>()
                .ForMember(userEntity => userEntity.UserInclusion, config => config.MapFrom(source => 1))
                .ForMember(userEntity => userEntity.UserTypeEntityId, config => config.MapFrom(source => 2))
                .ForMember(userEntity => userEntity.Password, config => config.Ignore())
                .IncludeBase<ABaseRequestInsert, BaseEntity>();
        }

        private void PilotMapping()
        {
            CreateMap<PilotEntity, PilotResponse>();

            CreateMap<PilotRequestInsert, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => source.GenderType == GenderTypeEnum.Male))
                .IncludeBase<ABaseRequestInsert, BaseEntity>();

            CreateMap<PilotRequestUpdate, PilotEntity>()
                .ForMember(pilotEntity => pilotEntity.GenderType, config => config.MapFrom(source => source.GenderType == GenderTypeEnum.Male))
                .IncludeBase<ABaseRequestUpdate, BaseEntity>();
        }
    }
}
