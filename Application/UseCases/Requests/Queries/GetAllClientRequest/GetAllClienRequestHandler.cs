using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;
using Application.UseCases.Requests.Queries.GetAllRequest;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.GetAllClientRequest
{
    public sealed class GetAllClientRequestHandler
        : IQueryHandler<GetAllClienRequestQueries, PagedList<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllClientRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<RequestResponse>>> Handle(GetAllClienRequestQueries request, CancellationToken cancellationToken)
        {
            var list = await _repo.requestRepo.GetAllClientRequestSSFP(request.SearchTerm, request.SortColumn, request.SortOrder, request.Page, request.Limit, cancellationToken);
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
