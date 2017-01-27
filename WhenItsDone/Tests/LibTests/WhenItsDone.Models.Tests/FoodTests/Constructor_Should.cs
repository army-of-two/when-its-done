using System;
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
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var type = typeof(Food);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var food = new Food();

            Assert.That(food, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void IdProperty_MustHaveKeyAttribute()
        {
            var id = typeof(Food).GetProperty("Id");

            var attribute = id.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NutritionFactsProperty_MustHaveRequiredAttribute()
        {
            var nutritionFacts = typeof(Food).GetProperty("NutritionFacts");

            var attribute = nutritionFacts.GetCustomAttribute(typeof(RequiredAttribute));

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

        [Test]
        public void NameProperty_MustHaveRequiredAttribute()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RequiredAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMinLengthAttribute()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MinLengthAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMinLengthAttributeWithCorrectValue()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MinLengthAttribute)) as MinLengthAttribute;
            var minimumConstraint = attribute.Length;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void NameProperty_MustHaveMaxLengthAttribute()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MaxLengthAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMaxLengthAttributeWithCorrectValue()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MaxLengthAttribute)) as MaxLengthAttribute;
            var minimumConstraint = attribute.Length;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.NameMaxLength));
        }

        [Test]
        public void NameProperty_MustHaveRegularExpressionAttribute()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RegularExpressionAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveRegularExpressionAttributeWithCorrectConstraint()
        {
            var name = typeof(Food).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RegularExpressionAttribute)) as RegularExpressionAttribute;
            var regexConstraint = attribute.Pattern;

            Assert.That(regexConstraint, Is.EqualTo(RegexConstants.EnBgSpaceMinus));
        }
    }
}
