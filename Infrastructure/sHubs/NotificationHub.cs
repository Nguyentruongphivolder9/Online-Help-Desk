using Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.sHubs
{
    public class NotificationHub : Hub
    {
        private readonly IUnitOfWorkRepository _repo;

        public NotificationHub(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task JoinToMultipleRoom(string accountId)
        {
            var accountJoined = await _repo.accountRepo.GetByAccountId(accountId);
            var listRequestRelateToUser = await _repo.requestRepo.GetAllRequestWithoutSSFP(accountJoined.AccountId);
            var listRequestOfOneAssignee = await _repo.assigneesRepo.GetListHandleRequestOfOneAssigneeByAccountId(accountJoined.AccountId);
            var listRequest = await _repo.requestRepo.GetAllAsync();

            if (accountJoined!.Role!.RoleTypes!.Id == 2 && accountJoined != null) // facility
            {
                foreach (var request in listRequest)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, request.Id.ToString());
                }
            }

            if (accountJoined!.Role!.RoleTypes.Id == 3 && accountJoined != null) // asignnee
            {
                if(listRequestOfOneAssignee!= null)
                {
                    foreach (var request in listRequestOfOneAssignee)
                    {
                        await Groups.AddToGroupAsync(Context.ConnectionId, request.RequestId.ToString());
                    }
                }
            }

            if (accountJoined!.Role!.RoleTypes.Id == 1 && accountJoined != null)
            {
                foreach (var request in listRequestRelateToUser)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, request.Id.ToString());
                }
            }
        }

    }
}
