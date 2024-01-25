using System;
using Application.Common.Messaging;
using Application.DTOs.Requests;
using Application.UseCases.Requests.Queries.GetAllRequest;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.SortingRequest
{
    public sealed class SortingRequestHandler
        : IQueryHandler<SortingRequestQueries, IEnumerable<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public SortingRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RequestResponse>>>
            Handle(SortingRequestQueries request, CancellationToken cancellationToken)
        {
            var list = await _repo.requestRepo.SortingRequest();
            if (list == null)
            {
                return Result.Failure<IEnumerable<RequestResponse>>(new Error("Error.Empty", "data null"), "List Request Sorting is Null");
            }
            var resultList = _mapper.Map<IEnumerable<RequestResponse>>(list);
            return Result.Success<IEnumerable<RequestResponse>>(resultList, "Get List Request Sorting successfully !");
        }
    }
}

