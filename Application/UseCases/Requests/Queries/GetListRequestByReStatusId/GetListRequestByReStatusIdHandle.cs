using System;
using System.Collections.Generic;
using Application.Common.Messaging;
using Application.DTOs.Requests;
using Application.UseCases.Requests.Queries.GetRequestById;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Queries.GetListRequestByReStatusId
{
    public sealed class GetListRequestByReStatusIdHandle
        : IQueryHandler<GetListRequestByReStatusIdQueries, IEnumerable<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetListRequestByReStatusIdHandle(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<RequestResponse>>>
            Handle(GetListRequestByReStatusIdQueries request,
            CancellationToken cancellationToken)
        {
            int id = request.Id;
            var requestQueryObj = await _repo.requestRepo.GetRequestByReStatusId(id);
            if (requestQueryObj == null)
            {
                return Result.Failure< IEnumerable<RequestResponse>> (new Error("Error.Empty", "data null"), "Request is Null");
            }

            var resultObject = _mapper.Map<IEnumerable<RequestResponse>>(requestQueryObj);
            return Result.Success<IEnumerable<RequestResponse>>(resultObject, "Get Request successfully !");
        }
    }
}

