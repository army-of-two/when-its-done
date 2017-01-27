using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.VitaminTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var type = typeof(Vitamin);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var vitamin = new Vitamin();

            Assert.That(vitamin, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void IdProperty_MustHaveKeyAttribute()
        {
            var recipe = typeof(Vitamin).GetProperty("Id");

            var attribute = recipe.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void QuantityProperty_MustHaveRangeAttribute()
        {
            var quantity = typeof(Vitamin).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void QuantityProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var quantity = typeof(Vitamin).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void QuantityProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var quantity = typeof(Vitamin).GetProperty("Quantity");

            var attribute = quantity.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }

        [Test]
        public void NameProperty_MustHaveRequiredAttribute()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RequiredAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMinLengthAttribute()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MinLengthAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMinLengthAttributeWithCorrectValue()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MinLengthAttribute)) as MinLengthAttribute;
            var minimumConstraint = attribute.Length;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.NameMinLength));
        }

        [Test]
        public void NameProperty_MustHaveMaxLengthAttribute()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MaxLengthAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveMaxLengthAttributeWithCorrectValue()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(MaxLengthAttribute)) as MaxLengthAttribute;
            var minimumConstraint = attribute.Length;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.NameMaxLength));
        }

        [Test]
        public void NameProperty_MustHaveRegularExpressionAttribute()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RegularExpressionAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void NameProperty_MustHaveRegularExpressionAttributeWithCorrectConstraint()
        {
            var name = typeof(Vitamin).GetProperty("Name");

            var attribute = name.GetCustomAttribute(typeof(RegularExpressionAttribute)) as RegularExpressionAttribute;
            var regexConstraint = attribute.Pattern;

            Assert.That(regexConstraint, Is.EqualTo(RegexConstants.EnBgSpaceMinus));
        }
    }
}
