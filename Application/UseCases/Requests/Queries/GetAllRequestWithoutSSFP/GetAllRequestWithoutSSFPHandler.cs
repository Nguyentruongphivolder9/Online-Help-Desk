using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;
using Application.UseCases.Requests.Queries.GetAllRequestWithoutSSFP;
namespace Application.UseCases.Requests.Queries.GetAllRequestWithoutSSFP
{
    public sealed class GetAllRequestWithoutSSFPHandler
        : IQueryHandler<GetAllRequestWithoutSSFPQueries, List<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllRequestWithoutSSFPHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<RequestResponse>>> Handle(GetAllRequestWithoutSSFPQueries request, CancellationToken cancellationToken)
        {

            var list = await _repo.requestRepo.GetAllRequestWithoutSSFP(request.AccountId);
            if (list == null)
            {
                return Result.Failure<List<RequestResponse>>(new Error("Error.Empty", "data null"), "List Request is Empty");
            }
            var resultList = _mapper.Map<List<RequestResponse>>(list);
          

            return Result.Success<List<RequestResponse>>(resultList, "Get List Request successfully !");
        }
    }
}
