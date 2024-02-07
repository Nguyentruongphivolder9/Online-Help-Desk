using System.Threading;
using System.Threading.Tasks;
using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Assigness.Queries.GetTotalRequest
{
    public sealed class GetTotalRequestHandler : IQueryHandler<GetTotalRequestQueries, int>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetTotalRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(GetTotalRequestQueries request, CancellationToken cancellationToken)
        {
            string accountId = request.AccountId;
            var getAccounAssigneeById = await _repo.accountRepo.GetByAccountId(accountId);
            if (getAccounAssigneeById == null)
            {
                return Result.Failure<int>(new Error("Error.Empty", "Data is null"), "Account is not exist");
            }
            if (getAccounAssigneeById.RoleId != 4)
            {
                return Result.Failure<int>(new Error("Error.Empty", "Data is null"), "This Account is not Assignee");
            }

            var countTotal = await _repo.assigneesRepo.GetTotalRequestofAssignee(accountId);
            if (countTotal >= 0)
            {
                return Result.Success(countTotal);
            }
            else
            {
                return Result.Failure<int>(new Error("Error.Empty", "Data is null"), "Count Total Request is error ");
            }
        }
    }
}
