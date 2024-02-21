using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotificationRemarkRepository : GenericRepository<NotificationRemark>, INotificationRemark
    {
        public NotificationRemarkRepository(OHDDbContext dbContext)
           : base(dbContext) { }

    }
}
