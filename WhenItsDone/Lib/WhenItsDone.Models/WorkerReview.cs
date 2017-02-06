using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class WorkerReview : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewContentMinLength)]
        [MaxLength(ValidationConstants.ReviewContentMaxLength)]
        public string ReviewContent { get; set; }

        [Range(ValidationConstants.ScoreMinValue, ValidationConstants.ScoreMaxValue)]
        public int Score { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public bool IsDeleted { get; set; }
    }
}
