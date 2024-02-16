using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Accounts;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Assigness.Queries.GetAllAssignees
{
    public sealed class GetAllAssigneesHandler
         : IQueryHandler<GetAllAssigneesQueries, PagedList<AccountDTO>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllAssigneesHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<AccountDTO>>> Handle(
            GetAllAssigneesQueries request,
            CancellationToken cancellationToken)
        {
            var list = await _repo.accountRepo.GetListAssigneesSSFP(request.SearchTerm, request.Page, request.Limit, cancellationToken);
            if (list.Items == null)
            {
                return Result.Failure<PagedList<AccountDTO>>(new Error("Error.Empty", "data null"),
                    "List Account Assignees is Null");

            }
            var resultList = _mapper.Map<List<AccountDTO>>(list.Items);
            var resultPageList = new PagedList<AccountDTO>
            {
                Items = resultList,
                Page = request.Page,
                Limit = request.Limit,
                TotalCount = list.TotalCount
            };
            return Result.Success(resultPageList, "Get List Account Assignees successfully !");
        }
    }
}

