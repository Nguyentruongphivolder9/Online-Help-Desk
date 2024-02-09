using Application.Common.Messaging;
using Application.DTOs.Accounts;
using AutoMapper;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Queries.GetAllRoleType
{
    public sealed class GetRoleTypeQueryHandler : IQueryHandler<GetAllRoleTypeQuery, List<RoleTypeResponse>>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;

        public GetRoleTypeQueryHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<List<RoleTypeResponse>>> Handle(GetAllRoleTypeQuery request, CancellationToken cancellationToken)
        {
            var roleTypes = await _repo.roleTypeRepo.GetAllAsync();
            if (roleTypes == null)
            {
                return Result.Failure<List<RoleTypeResponse>>(new Error("Error.Empty", "data null"), "Empty account role type data.");
            }
            var resultList = _mapper.Map<List<RoleTypeResponse>>(roleTypes);
            return Result.Success<List<RoleTypeResponse>>(resultList, "Get successful account role type data!");
        }
    }
}
