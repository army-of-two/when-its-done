using System.Collections.Generic;

namespace WhenItsDone.Models
{
    public class NutritionFacts
    {
        private ICollection<Vitamin> vitamins;
        private ICollection<Mineral> minerals;

        public NutritionFacts()
        {
            this.vitamins = new HashSet<Vitamin>();
            this.minerals = new HashSet<Mineral>();
        }

        public int Id { get; set; }

        public decimal Calories { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fats { get; set; }

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
    }
}
