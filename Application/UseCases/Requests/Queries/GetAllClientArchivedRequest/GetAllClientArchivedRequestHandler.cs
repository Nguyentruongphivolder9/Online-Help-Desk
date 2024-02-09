using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.GetAllClientArchivedRequest
{
    public sealed class GetAllClientArchivedRequestHandler
        : IQueryHandler<GetAllClientArchivedRequestQueries, PagedList<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllClientArchivedRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<RequestResponse>>> Handle(GetAllClientArchivedRequestQueries request, CancellationToken cancellationToken)
        {
            var user = await _repo.accountRepo.GetByAccountId(request.AccountId!);
            if (user == null)
            {
                return (Result<PagedList<RequestResponse>>)Result.Success("You don't have any requests yet");
            }

            var list = await _repo.requestRepo.GetAllClientUnenableRequestSSFP(request.AccountId,
                request.FCondition, request.SCondition, request.TCondition,
                request.SearchTerm, request.SortColumn, request.SortOrder,
                request.Page, request.Limit, cancellationToken);
            if (list == null)
            {
                return Result.Failure<PagedList<RequestResponse>>(new Error("Error.Empty", "data null"), "List Request is Null");
            }
            var resultList = _mapper.Map<List<RequestResponse>>(list.Items);
            var resultPageList = new PagedList<RequestResponse>
            {
                Items = resultList,
                Page = request.Page,
                Limit = request.Limit,
                TotalCount = list.TotalCount
            };

            return Result.Success<PagedList<RequestResponse>>(resultPageList, "Get List Request successfully !");
        }
    }
}
