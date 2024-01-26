using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.GetRequestById
{
    public sealed class GetRequestByIdQueriesHandler : IQueryHandler<GetRequestByIdQueries, RequestResponse>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetRequestByIdQueriesHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<RequestResponse>> Handle(GetRequestByIdQueries request, CancellationToken cancellationToken)
        {
            Guid id = request.Id;
            var requestQueryObj = await _repo.requestRepo.GetRequestById(id);
            if(requestQueryObj == null)
            {
                return Result.Failure<RequestResponse>(new Error("Error.Empty", "data null"), "Request is Null");
            } 

            var resultObject = _mapper.Map<RequestResponse>(requestQueryObj);
            return  Result.Success<RequestResponse>(resultObject, "Get Request successfully !");
        }
    }
}
