using Domain.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.sHubs
{
    public class BannedHub : Hub
    {
        private readonly IUnitOfWorkRepository _repo;

        public BannedHub(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task LogoutAccountWhenBanned(string accountId) 
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, accountId);
        }

    }
}
