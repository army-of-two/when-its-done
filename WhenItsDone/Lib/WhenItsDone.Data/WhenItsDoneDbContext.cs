using System.Data.Entity;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Factories;
using WhenItsDone.Models;

namespace WhenItsDone.Data
{
    public class WhenItsDoneDbContext : DbContext, IWhenItsDoneDbContext
    {
        private IStatefulFactory statefulFactory;

        // Migrations need an empty ctor
        public WhenItsDoneDbContext()
            : base("DefaultConnection")
        {
        }

        public WhenItsDoneDbContext(IStatefulFactory statefulFactory)
            : base("DefaultConnection")
        {
            this.statefulFactory = statefulFactory;
        }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<Client> Clients { get; set; }

        public virtual IDbSet<ClientReview> ClientReviews { get; set; }

        public virtual IDbSet<ContactInformation> ContactInformations { get; set; }

        public virtual IDbSet<Dish> Dishes { get; set; }

        public virtual IDbSet<Food> Foods { get; set; }

        public virtual IDbSet<Ingredient> Ingredients { get; set; }

        public virtual IDbSet<Job> Jobs { get; set; }

        public virtual IDbSet<Mineral> Minerals { get; set; }

        public virtual IDbSet<NutritionFacts> NutritionFacts { get; set; }

        public virtual IDbSet<Payment> Payments { get; set; }

        public virtual IDbSet<PhotoItem> PhotoItems { get; set; }

        public virtual IDbSet<ReceivedPayment> ReceivedPayments { get; set; }

        public virtual IDbSet<Recipe> Recipes { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<VideoItem> VideoItems { get; set; }

        public virtual IDbSet<Vitamin> Vitamins { get; set; }

        public virtual IDbSet<Worker> Workers { get; set; }

        public virtual IDbSet<MedicalInformation> VitalStatistics { get; set; }

        public virtual IDbSet<WorkerReview> WorkerReviews { get; set; }

        public IStateful<TEntity> GetStateful<TEntity>(TEntity entity) where TEntity : class
        {
            return this.statefulFactory.CreateStateful(base.Entry<TEntity>(entity));
        }
    }
}
