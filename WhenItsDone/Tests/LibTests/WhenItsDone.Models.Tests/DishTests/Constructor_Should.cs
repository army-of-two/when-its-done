using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.DishTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var dish = new Dish();

            Assert.That(dish, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void ShouldInitialize_PhotoItemsCollectionCorrectly()
        {
            var dish = new Dish();

            var photoItems = dish.PhotoItems;

            Assert.That(photoItems, Is.Not.Null.And.InstanceOf<HashSet<PhotoItem>>());
        }

        [Test]
        public void RecipeProperty_MustHaveRequiredAttribute()
        {
            var recipe = typeof(Dish).GetProperty("Recipe");

            var attribute = recipe.GetCustomAttribute(typeof(RequiredAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PriceProperty_MustHaveRangeAttribute()
        {
            var price = typeof(Dish).GetProperty("Price");

            var attribute = price.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PriceProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var price = typeof(Dish).GetProperty("Price");

            var attribute = price.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.DishPriceMinValue));
        }

        [Test]
        public void PriceProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var price = typeof(Dish).GetProperty("Price");

            var attribute = price.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.DishPriceMaxValue));
        }
    }
}
