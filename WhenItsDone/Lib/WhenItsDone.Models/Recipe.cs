using System.Collections.Generic;

namespace WhenItsDone.Models
{
    public class Recipe
    {
        private ICollection<Ingredient> ingredients;

        public Recipe()
        {
            this.ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Ingredient> Ingredients
        {
            get
            {
                return this.ingredients;
            }

            set
            {
                this.ingredients = value;
            }
        }
    }
}
