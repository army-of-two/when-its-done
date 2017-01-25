using System;
using System.Data.Entity;
using WhenItsDone.Data.Adapters;
using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Factories;
using WhenItsDone.Models;

namespace WhenItsDone.Data
{
    public class WhenItsDoneDbContext : DbContext, IWhenItsDoneDbContext
    {
        private IStatefulFactory statefulFactory;

        public WhenItsDoneDbContext(IStatefulFactory statefulFactory)
            : base("DefaultConnection")
        {
            this.statefulFactory = statefulFactory;
        }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<Client> Clients { get; set; }

        public virtual IDbSet<ClientReview> ClientReviews { get; set; }

        public virtual IDbSet<ContactInformation> ContactInformations { get; set; }

        public virtual IDbSet<Job> Jobs { get; set; }

        public virtual IDbSet<Payment> Payments { get; set; }

        public virtual IDbSet<PhotoItem> PhotoItems { get; set; }

        public virtual IDbSet<ReceivedPayment> ReceivedPayments { get; set; }

        public virtual IDbSet<VideoItem> VideoItems { get; set; }

        public virtual IDbSet<Worker> Workers { get; set; }

        public virtual IDbSet<VitalStatistics> VitalStatistics { get; set; }

        public virtual IDbSet<WorkerReview> WorkerReviews { get; set; }

        public IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class
        {
            return this.statefulFactory.GetStateful(base.Entry<TEntity>(entity));
        }
    }
}
