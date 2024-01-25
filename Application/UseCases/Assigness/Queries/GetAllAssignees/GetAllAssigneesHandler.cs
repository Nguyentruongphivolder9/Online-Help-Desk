using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Assigness.Queries.GetAllAssignees
{
    public sealed class GetAllAssigneesHandler
         : IQueryHandler<GetAllAssigneesQueries, IEnumerable<ProcessByAssigneesDTO>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllAssigneesHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProcessByAssigneesDTO>>> Handle(
            GetAllAssigneesQueries request,
            CancellationToken cancellationToken)
        {
            var list = await _repo.assigneesRepo.GetListAssignees();
            if (list == null)
            {
                return Result.Failure <IEnumerable<ProcessByAssigneesDTO>>
                    (new Error("Error.Empty", "data null"), "List Assignees Data is Null");
            }
            var resultList = _mapper.Map<IEnumerable<ProcessByAssigneesDTO>>(list);
            return Result.Success<IEnumerable<ProcessByAssigneesDTO>>
                (resultList, "Get List Assignees data successfully !");
        }
    }
}

