using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenItsDone.Models.Contracts
{
    public interface IJob : IDbModel
    {
        DateTime ScheduledTime { get; set; }

        decimal Price { get; set; }

        int WorkerId { get; set; }

        IWorker Worker { get; set; }

        int ClientId { get; set; }

        IClient Client { get; set; }

        bool IsCompleted { get; set; }
    }
}
