using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
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
            CreateMap<RequestInsertPilotJson, PilotEntity>();
        }

        private void EntityToResponse()
        {
            CreateMap<PilotEntity, ResponsePilotJson>();
                //.ForMember(dest => dest.Name, config=> config.MapFrom(source=> source.Name));
        }
    }
}
