using System;

using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Task : IDbModel
    {
        public int Id { get; set; }

        public DateTime ScheduledTime { get; set; }

        public decimal Price { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
