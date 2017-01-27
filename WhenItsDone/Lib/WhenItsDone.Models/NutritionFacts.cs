using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class NutritionFacts : IDbModel
    {
        private ICollection<Vitamin> vitamins;
        private ICollection<Mineral> minerals;

        public NutritionFacts()
        {
            this.vitamins = new HashSet<Vitamin>();
            this.minerals = new HashSet<Mineral>();
        }

        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Calories { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Carbohydrates { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Fats { get; set; }

        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public decimal Protein { get; set; }

        public virtual ICollection<Vitamin> Vitamins
        {
            get
            {
                return this.vitamins;
            }

            set
            {
                this.vitamins = value;
            }
        }

        public virtual ICollection<Mineral> Minerals
        {
            get
            {
                return this.minerals;
            }

            set
            {
                this.minerals = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
