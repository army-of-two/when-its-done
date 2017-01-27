using System.ComponentModel.DataAnnotations;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.FoodTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var food = new Food();

            Assert.That(food, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void IdProperty_MustHaveKeyAttribute()
        {
            var recipe = typeof(Food).GetProperty("Id");

            var attribute = recipe.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NutritionFactsProperty_MustHaveRequiredAttribute()
        {
            var recipe = typeof(Food).GetProperty("NutritionFacts");

            var attribute = recipe.GetCustomAttribute(typeof(RequiredAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttribute()
        {
            var pricePerUnit = typeof(Food).GetProperty("PricePerUnit");

            var attribute = pricePerUnit.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var pricePerUnit = typeof(Food).GetProperty("PricePerUnit");

            var attribute = pricePerUnit.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.DishPriceMinValue));
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var pricePerUnit = typeof(Food).GetProperty("PricePerUnit");

            var attribute = pricePerUnit.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.DishPriceMaxValue));
        }
    }
}
