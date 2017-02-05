using System;
using System.Data.Entity;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Models;
using WhenItsDone.Data.Factories;

namespace WhenItsDone.Data.Tests.WhenItsDoneDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var contextType = typeof(WhenItsDoneDbContext);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = contextType.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstanceOfDbContext()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<DbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstanceOfIWhenItsDoneDbContext()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            Assert.That(whenItsDoneDbContext, Is.InstanceOf<IWhenItsDoneDbContext>());
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressesProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithAddressVirtualProperty_OfTypeIDbSetAddresses()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Addresses";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var addressesProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(addressesProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Address>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientsVirtualProperty_OfTypeIDbSetClients()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Clients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Client>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithClientReviewsVirtualProperty_OfTypeIDbSetClientReviews()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ClientReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ClientReview>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithContactInformationsVirtualProperty_OfTypeIDbSetContactInformations()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ContactInformations";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ContactInformation>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithDishesProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Dishes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithDishesVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Dishes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithDishesVirtualProperty_OfTypeIDbSetDishes()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Dishes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Dish>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithFoodsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Foods";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithFoodsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Foods";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithFoodsVirtualProperty_OfTypeIDbSetFoods()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Foods";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Food>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithIngredientsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Ingredients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithIngredientsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Ingredients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithIngredientsVirtualProperty_OfTypeIDbSetIngredients()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Ingredients";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Ingredient>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithJobsVirtualProperty_OfTypeIDbSetJobs()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Jobs";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Job>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMineralsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Minerals";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMineralsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Minerals";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMineralsVirtualProperty_OfTypeIDbSetMinerals()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Minerals";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Mineral>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithNutritionFactsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "NutritionFacts";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithNutritionFactsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "NutritionFacts";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithNutritionFactsVirtualProperty_OfTypeIDbSetNutritionFacts()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "NutritionFacts";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<NutritionFacts>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPaymentsVirtualProperty_OfTypeIDbSetPayments()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Payments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Payment>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithPhotoItemsVirtualProperty_OfTypeIDbSetPhotoItems()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "PhotoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<PhotoItem>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithReceivedPaymentsVirtualProperty_OfTypeIDbSetReceivedPayments()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "ReceivedPayments";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<ReceivedPayment>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithRecipesProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Recipes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithRecipesVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Recipes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithRecipesVirtualProperty_OfTypeIDbSetRecipes()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Recipes";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Recipe>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVideoItemsVirtualProperty_OfTypeIDbSetVideoItems()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "VideoItems";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<VideoItem>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitaminsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Vitamins";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitaminsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Vitamins";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithVitaminsVirtualProperty_OfTypeIDbSetVitamins()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Vitamins";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Vitamin>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkersVirtualProperty_OfTypeIDbSetWorkers()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "Workers";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<Worker>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMedicalInformationProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "MedicalInformation";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMedicalInformationVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "MedicalInformation";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithMedicalInformationVirtualProperty_OfTypeIDbSetMedicalInformation()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "MedicalInformation";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<MedicalInformation>)));
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsVirtualProperty()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.GetGetMethod().IsVirtual, Is.True);
        }

        [Test]
        public void ShouldCreateAValidInstance_WithWorkerReviewsVirtualProperty_OfTypeIDbSetWorkerReviews()
        {
            var mockedFactory = new Mock<IStatefulFactory>();

            var whenItsDoneDbContext = new WhenItsDoneDbContext(mockedFactory.Object);

            var propertyName = "WorkerReviews";
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            var clientsProperty = whenItsDoneDbContext.GetType().GetProperty(propertyName, bindingFlags);

            Assert.That(clientsProperty.PropertyType, Is.EqualTo(typeof(IDbSet<WorkerReview>)));
        }
    }
}
