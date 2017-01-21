using System.Data.Entity;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;

namespace WhenItsDone.Data.Tests.WhenItsDoneDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldCreateAValidInstanceOfDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstanceOfIWhenItsDoneDbContext()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<IWhenItsDoneDbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressesProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty_OfTypeIDbSetAddresses()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Address>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsVirtualProperty_OfTypeIDbSetClients()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Client>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsVirtualProperty_OfTypeIDbSetClientReviews()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ClientReview>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsVirtualProperty_OfTypeIDbSetContactInformations()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ContactInformation>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsVirtualProperty_OfTypeIDbSetJobs()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Job>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsVirtualProperty_OfTypeIDbSetPayments()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Payment>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsVirtualProperty_OfTypeIDbSetPhotoItems()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<PhotoItem>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsVirtualProperty_OfTypeIDbSetReceivedPayments()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ReceivedPayment>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsVirtualProperty_OfTypeIDbSetVideoItems()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<VideoItem>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersVirtualProperty_OfTypeIDbSetWorkers()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Worker>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitalStatisticsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VitalStatistics";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitalStatisticsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VitalStatistics";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitalStatisticsVirtualProperty_OfTypeIDbSetVitalStatistics()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "VitalStatistics";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<VitalStatistics>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsVirtualProperty()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsVirtualProperty_OfTypeIDbSetWorkerReviews()
        {
            var whenItsDoneDbContext = new WhenItsDoneDbContext();

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<WorkerReview>)));
        }
    }
}
