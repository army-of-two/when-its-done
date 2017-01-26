using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models
{
    public class Dish
    {
        private ICollection<PhotoItem> photoItems;

        public Dish()
        {
            this.photoItems = new HashSet<PhotoItem>();
        }

        [Key]
        public int Id { get; set; }

        public int RecipeId { get; set; }

        [Required]
        public virtual Recipe Recipe { get; set; }

        [Range(ValidationConstants.DishPriceMinValue, ValidationConstants.DishPriceMaxValue)]
        public decimal Price { get; set; }

        public virtual ICollection<PhotoItem> PhotoItems
        {
            get
            {
                return this.photoItems;
            }

            set
            {
                this.photoItems = value;
            }
        }
    }
}
