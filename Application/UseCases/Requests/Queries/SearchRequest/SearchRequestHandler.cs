using System;
using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.SearchRequest
{
    public sealed class SearchRequestHandler
        : IQueryHandler<SearchRequestQueries, IEnumerable<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public SearchRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RequestResponse>>> Handle(
            SearchRequestQueries request, CancellationToken cancellationToken)
        {
            try
            {
                var searchResults = await _repo.requestRepo.SearchRequestsAsync(request.Search);
                var mappedResults = _mapper.Map<IEnumerable<RequestResponse>>(searchResults);

                return Result.Success<IEnumerable<RequestResponse>>(mappedResults, "Search Contain Successfully at ListRequest Page !");
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<RequestResponse>>(new Error("Error.Empty", "data null"), ex.Message);
            }
        }
    }

}

