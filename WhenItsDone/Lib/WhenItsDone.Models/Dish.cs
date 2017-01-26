using System.Collections.Generic;

namespace WhenItsDone.Models
{
    public class Dish
    {
        private ICollection<PhotoItem> photoItems;

        public Dish()
        {
            this.photoItems = new HashSet<PhotoItem>();
        }

        public int Id { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

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
