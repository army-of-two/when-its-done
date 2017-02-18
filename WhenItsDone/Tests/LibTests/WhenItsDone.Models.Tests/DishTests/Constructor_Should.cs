using System;
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
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var type = typeof(Dish);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

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
        public void IdProperty_MustHaveKeyAttribute()
        {
            var recipe = typeof(Dish).GetProperty("Id");

            var attribute = recipe.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Ignore("Intentionally removed.")]
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

        [Test]
        public void RatingProperty_MustHaveRangeAttribute()
        {
            var rating = typeof(Dish).GetProperty("Rating");

            var attribute = rating.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void RatingProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var rating = typeof(Dish).GetProperty("Rating");

            var attribute = rating.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.RatingMinValue));
        }

        [Test]
        public void RatingProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var rating = typeof(Dish).GetProperty("Rating");

            var attribute = rating.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.RatingMaxValue));
        }
    }
}
