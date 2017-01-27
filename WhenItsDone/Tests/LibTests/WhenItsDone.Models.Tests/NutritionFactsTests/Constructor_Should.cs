using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

using NUnit.Framework;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models.Tests.NutritionFactsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldHaveDefaultParameterlessCtor()
        {
            var type = typeof(NutritionFacts);

            var ctorParameters = new Type[] { };
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructor = type.GetConstructor(bindingFlags, null, ctorParameters, null);

            Assert.That(constructor, Is.Not.Null);
        }

        [Test]
        public void ShouldInitialize_ImplementingIDbModel()
        {
            var nutritionFacts = new NutritionFacts();

            Assert.That(nutritionFacts, Is.Not.Null.And.InstanceOf<IDbModel>());
        }

        [Test]
        public void ShouldInitialize_VitaminsCollectionCorrectly()
        {
            var nutritionFacts = new NutritionFacts();

            var vitamins = nutritionFacts.Vitamins;

            Assert.That(vitamins, Is.Not.Null.And.InstanceOf<HashSet<Vitamin>>());
        }

        [Test]
        public void ShouldInitialize_MineralsCollectionCorrectly()
        {
            var nutritionFacts = new NutritionFacts();

            var minerals = nutritionFacts.Minerals;

            Assert.That(minerals, Is.Not.Null.And.InstanceOf<HashSet<Mineral>>());
        }

        [Test]
        public void IdProperty_MustHaveKeyAttribute()
        {
            var recipe = typeof(NutritionFacts).GetProperty("Id");

            var attribute = recipe.GetCustomAttribute(typeof(KeyAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void CaloriesProperty_MustHaveRangeAttribute()
        {
            var calories = typeof(NutritionFacts).GetProperty("Calories");

            var attribute = calories.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void CaloriesProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var calories = typeof(NutritionFacts).GetProperty("Calories");

            var attribute = calories.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void CaloriesProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var calories = typeof(NutritionFacts).GetProperty("Calories");

            var attribute = calories.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }

        [Test]
        public void CarbohydratesProperty_MustHaveRangeAttribute()
        {
            var carbohydrates = typeof(NutritionFacts).GetProperty("Carbohydrates");

            var attribute = carbohydrates.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void CarbohydratesProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var carbohydrates = typeof(NutritionFacts).GetProperty("Carbohydrates");

            var attribute = carbohydrates.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void CarbohydratesProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var carbohydrates = typeof(NutritionFacts).GetProperty("Carbohydrates");

            var attribute = carbohydrates.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }

        [Test]
        public void FatsProperty_MustHaveRangeAttribute()
        {
            var fats = typeof(NutritionFacts).GetProperty("Fats");

            var attribute = fats.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void FatsProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var fats = typeof(NutritionFacts).GetProperty("Fats");

            var attribute = fats.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void FatsProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var fats = typeof(NutritionFacts).GetProperty("Fats");

            var attribute = fats.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }

        [Test]
        public void ProteinProperty_MustHaveRangeAttribute()
        {
            var protein = typeof(NutritionFacts).GetProperty("Protein");

            var attribute = protein.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

            Assert.That(attribute, Is.Not.Null);
        }

        [Test]
        public void ProteinProperty_MustHaveRangeAttributeWithCorrectMinimumConstraints()
        {
            var protein = typeof(NutritionFacts).GetProperty("Protein");

            var attribute = protein.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var minimumConstraint = attribute.Minimum;

            Assert.That(minimumConstraint, Is.EqualTo(ValidationConstants.QuantityMinValue));
        }

        [Test]
        public void ProteinProperty_MustHaveRangeAttributeWithCorrectMaximumConstraints()
        {
            var protein = typeof(NutritionFacts).GetProperty("Protein");

            var attribute = protein.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)) as System.ComponentModel.DataAnnotations.RangeAttribute;
            var maximumConstraint = attribute.Maximum;

            Assert.That(maximumConstraint, Is.EqualTo(ValidationConstants.QuantityMaxValue));
        }
    }
}
