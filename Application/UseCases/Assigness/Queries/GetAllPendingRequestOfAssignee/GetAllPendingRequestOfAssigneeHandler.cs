﻿using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Assigness.Queries.GetAllPendingRequestOfAssignee
{
    public class GetAllPendingRequestOfAssigneeHandler
          : IQueryHandler<GetAllPendingRequestOfAssigneeQueries, PagedList<RequestResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetAllPendingRequestOfAssigneeHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<Result<PagedList<RequestResponse>>> Handle(GetAllPendingRequestOfAssigneeQueries request, CancellationToken cancellationToken)
        {
            var list = await _repo.assigneesRepo.GetAllPendingRequestOfAssigneeSSFP
                 (request.AccountId,request.SearchTerm, request.SortColumn, request.SortOrder
                 , request.SortStatus, request.Page, request.Limit, cancellationToken);
            if (list == null)
            {
                return Result.Failure<PagedList<RequestResponse>>(new Error("Error.Empty", "data null"), "List PendingRequest Of Assignee is Null");
            }
            var resultList = _mapper.Map<List<RequestResponse>>(list.Items);
            var resultPageList = new PagedList<RequestResponse>
            {
                Items = resultList,
                Page = request.Page,
                Limit = request.Limit,
                TotalCount = list.TotalCount
            };

            return Result.Success<PagedList<RequestResponse>>(resultPageList, "Get List Pending Request of Assignee successfully !");
        }
    }
}

