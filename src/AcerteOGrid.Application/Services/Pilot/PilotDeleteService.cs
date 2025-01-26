
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotDeleteService : IPilotDeleteService
    {
        private readonly IPilotWriteOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PilotDeleteService(IPilotWriteOnlyRespository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int id)
        {
            var result = await _repository.Delete(id);

            if (!result)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
