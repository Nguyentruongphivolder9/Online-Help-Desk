using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Assigness.Queries.GetAllAssignees
{
    public sealed class GetAllAssigneesHandler
         : IQueryHandler<GetAllAssigneesQueries, IEnumerable<AccountDTO>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllAssigneesHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<AccountDTO>>> Handle(
            GetAllAssigneesQueries request,
            CancellationToken cancellationToken)
        {
            var list = await _repo.accountRepo.GetListAssignees();
            if (list == null)
            {
                return Result.Failure <IEnumerable<AccountDTO>>
                    (new Error("Error.Empty", "data null"), "List Assignees Data is Null");
            }
            var resultList = _mapper.Map<IEnumerable<AccountDTO>>(list);

            return Result.Success<IEnumerable<AccountDTO>>
                (resultList, "Get List Assignees data successfully !");
        }
    }
}

