using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models
{
    public class Recipe
    {
        private ICollection<Ingredient> ingredients;

        public Recipe()
        {
            this.ingredients = new HashSet<Ingredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NameMinLength)]
        [MaxLength(ValidationConstants.NameMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
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
