using System.Data.Entity;

namespace WhenItsDone.Data.EntityDataSourceContainer
{
    public interface IEntities
    {
        DbSet<Addresses> Addresses { get; set; }
        DbSet<ClientReviews> ClientReviews { get; set; }
        DbSet<Clients> Clients { get; set; }
        DbSet<ContactInformations> ContactInformations { get; set; }
        DbSet<Dishes> Dishes { get; set; }
        DbSet<Foods> Foods { get; set; }
        DbSet<Ingredients> Ingredients { get; set; }
        DbSet<Jobs> Jobs { get; set; }
        DbSet<MedicalInformations> MedicalInformations { get; set; }
        DbSet<Minerals> Minerals { get; set; }
        DbSet<NutritionFacts> NutritionFacts { get; set; }
        DbSet<Payments> Payments { get; set; }
        DbSet<PhotoItems> PhotoItems { get; set; }
        DbSet<ProfilePictures> ProfilePictures { get; set; }
        DbSet<ReceivedPayments> ReceivedPayments { get; set; }
        DbSet<Recipes> Recipes { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<VideoItems> VideoItems { get; set; }
        DbSet<Vitamins> Vitamins { get; set; }
        DbSet<WorkerReviews> WorkerReviews { get; set; }
        DbSet<Workers> Workers { get; set; }
    }
}
