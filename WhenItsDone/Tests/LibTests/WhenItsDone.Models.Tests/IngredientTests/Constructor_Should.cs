using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.IngredientTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var type = typeof(Ingredient);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var ingredient = new Ingredient();

            Assert.That(ingredient, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void IdProperty_MustHaveKeyAttribute()
        {
            var id = typeof(Ingredient).GetProperty("Id");

            var attribute = id.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NutritionFactsProperty_MustHaveRequiredAttribute()
        {
            var food = typeof(Ingredient).GetProperty("Food");

            var attribute = food.GetCustomAttribute(typeof(RequiredAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttribute()
        {
            var quantity = typeof(Ingredient).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var quantity = typeof(Ingredient).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void PricePerUnitProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var quantity = typeof(Ingredient).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }
    }
}
