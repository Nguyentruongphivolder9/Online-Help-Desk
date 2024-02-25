using Application.Common.Messaging;
using Application.DTOs.Remarks;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;

using SharedKernel;
using System.Collections.Generic;

namespace Application.UseCases.Remarks.Command.CreateRemark
{
    public sealed class CreateRemarkHandler : ICommandHandler<CreateRemarkCommand, RemarkDTO>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;
        public CreateRemarkHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result<RemarkDTO>> Handle(CreateRemarkCommand request, CancellationToken cancellationToken)
        {
            var listfacilityHeads = await _repo.accountRepo.GetAllFacilityHeads();
            var listAssigneeRalateToRequestId = await _repo.assigneesRepo.GetListByAssigneeHandleRequest(Guid.Parse(request.RequestId));
            var listNotifiRemarkRelateToRequestId = await _repo.notificationRemarkRepo.GetNotificationRemarkByRequestId(Guid.Parse(request.RequestId));
            var accountChatting = await _repo.accountRepo.GetByAccountId(request.AccountId);
            var remarkData = new Remark
            {
                Id = new Guid(),
                AccountId = request.AccountId,
                RequestId = new Guid(request.RequestId),
                Comment = request.Comment,
                CreateAt = DateTime.Now,
                Enable = true
            };
            _repo.remarkRepo.Add(remarkData);

            if (accountChatting != null)
            {
                foreach (var head in listfacilityHeads)
                {
                    var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                FirstOrDefault(notifiRemark => notifiRemark.AccountId == head.AccountId);
                    if (head.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                    {
                        foundNotifiRemark.Unwatchs += 1;
                        foundNotifiRemark.IsSeen = false;
                        _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                    }
                }

                if (listAssigneeRalateToRequestId != null)
                {
                    foreach (var assignee in listAssigneeRalateToRequestId)
                    {
                        var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                FirstOrDefault(notifiRemark => notifiRemark.AccountId == assignee.AccountId);

                        if (assignee.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                        {
                            foundNotifiRemark.Unwatchs += 1;
                            foundNotifiRemark.IsSeen = false;
                            _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                        }
                    }
                }

                if (accountChatting != null &&
                   (accountChatting.Role?.RoleTypes?.Id == 2 ||
                    accountChatting.Role?.RoleTypes?.Id == 3))
                {

                    var foundNotifiRemarkOfUser = listNotifiRemarkRelateToRequestId.
                                                FirstOrDefault(notifiRemark => notifiRemark.RequestId == Guid.Parse(request.RequestId));
                    if (foundNotifiRemarkOfUser != null)
                    {
                        foundNotifiRemarkOfUser.Unwatchs += 1;
                        foundNotifiRemarkOfUser.IsSeen = false;
                        _repo.notificationRemarkRepo.Update(foundNotifiRemarkOfUser);
                    }
                }
            }

                /*if (accountChatting != null &&
                       string.Equals(accountChatting.Role!.RoleTypes!.RoleTypeName, "Facility-Heads", StringComparison.OrdinalIgnoreCase) &&
                       accountChatting.Role.RoleTypes.Id == 2)
                {
                    foreach (var head in listfacilityHeads)
                    {
                        var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.AccountId == head.AccountId);
                        if (head.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                        {
                            foundNotifiRemark.Unwatchs += 1;
                            _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                        }
                    }

                    if (listAssigneeRalateToRequestId != null)
                    {
                        foreach (var assignee in listAssigneeRalateToRequestId)
                        {
                            var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.AccountId == assignee.AccountId);

                            if (assignee.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                            {
                                foundNotifiRemark.Unwatchs += 1;
                                _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                            }
                        }
                    }

                    var foundNotifiRemarkOfUser = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.RequestId == Guid.Parse(request.RequestId));
                    if (foundNotifiRemarkOfUser != null)
                    {
                        foundNotifiRemarkOfUser.Unwatchs += 1;
                        _repo.notificationRemarkRepo.Update(foundNotifiRemarkOfUser);
                    }

                }

                if (accountChatting != null &&
                       string.Equals(accountChatting.Role!.RoleTypes!.RoleTypeName, "Assignees", StringComparison.OrdinalIgnoreCase) &&
                       accountChatting.Role.RoleTypes.Id == 3)
                {
                    foreach (var head in listfacilityHeads)
                    {
                        var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.AccountId == head.AccountId);
                        if (head.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                        {
                            foundNotifiRemark.Unwatchs += 1;
                            _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                        }
                    }

                    if (listAssigneeRalateToRequestId != null)
                    {
                        foreach (var assignee in listAssigneeRalateToRequestId)
                        {
                            var foundNotifiRemark = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.AccountId == assignee.AccountId);

                            if (assignee.AccountId != accountChatting.AccountId && foundNotifiRemark != null)
                            {
                                foundNotifiRemark.Unwatchs += 1;
                                _repo.notificationRemarkRepo.Update(foundNotifiRemark);
                            }
                        }
                    }

                    var foundNotifiRemarkOfUser = listNotifiRemarkRelateToRequestId.
                                                    FirstOrDefault(notifiRemark => notifiRemark.RequestId == Guid.Parse(request.RequestId));
                    if (foundNotifiRemarkOfUser != null)
                    {
                        foundNotifiRemarkOfUser.Unwatchs += 1;
                        _repo.notificationRemarkRepo.Update(foundNotifiRemarkOfUser);
                    }
                }*/


            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                var latestRemark = await _repo.remarkRepo.GetLatestRemark(remarkData.Id.ToString().ToUpper());
                var latestRemarkMapper = _mapper.Map<RemarkDTO>(latestRemark);

                return Result.Success<RemarkDTO>(latestRemarkMapper, "Create remark successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.RemarkCommandHandler", "There is an error saving data!");
                return Result.Failure<RemarkDTO>(error, "Create Remark failed!");
            }
        }

        
    }
}
