using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotificationRemarkRepository : GenericRepository<NotificationRemark>, INotificationRemarkRepository
    {

        public NotificationRemarkRepository(OHDDbContext dbContext)
           : base(dbContext) { }

        public async Task<List<NotificationRemark>> GetNotificationRemarkByRequestId(Guid requestId)
        {
            var listNotifiRemarkByRequestId = await _dbContext.Set<NotificationRemark>().Where(re => re.RequestId == requestId).ToListAsync();
            return listNotifiRemarkByRequestId;
        }
    }
}
