using System.Data.Entity;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;

namespace WhenItsDone.Data
{
    public class WhenItsDoneDbContext : DbContext, IWhenItsDoneDbContext
    {
        public WhenItsDoneDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<Client> Clients { get; set; }

        public virtual IDbSet<ClientReview> ClientReviews { get; set; }

        public virtual IDbSet<ContactInformation> ContactInformations { get; set; }

        public virtual IDbSet<Job> Jobs { get; set; }

        public virtual IDbSet<PhotoItem> PhotoItems { get; set; }

        public virtual IDbSet<VideoItem> VideoItems { get; set; }

        public virtual IDbSet<Worker> Workers { get; set; }

        public virtual IDbSet<VitalStatistics> VitalStatistics { get; set; }

        public virtual IDbSet<WorkerReview> WorkerReviews { get; set; }
    }
}
