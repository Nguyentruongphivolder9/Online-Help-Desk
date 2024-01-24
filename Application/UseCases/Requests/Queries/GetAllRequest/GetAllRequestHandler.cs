using System.Globalization;
using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.GetAllRequest
{
    public sealed class GetAllRequestHandler
        : IQueryHandler<GetAllRequestQueries, IEnumerable<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RequestResponse>>> Handle(GetAllRequestQueries request, CancellationToken cancellationToken)
        {
            var list = await _repo.requestRepo.GetAllRequest();
            if (list == null)
            {
                return Result.Failure<IEnumerable<RequestResponse>>(new Error("Error.Empty", "data null"), "List Request is Null");
            }
            var resultList = _mapper.Map<IEnumerable<RequestResponse>>(list);
            return Result.Success<IEnumerable<RequestResponse>>(resultList , "Get List Request successfully !");
        }
    }
}

