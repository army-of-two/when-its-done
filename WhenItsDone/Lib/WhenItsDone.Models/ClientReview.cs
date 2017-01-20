using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ClientReview : IDbModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ReviewContentMinLength)]
        [MaxLength(ValidationConstants.ReviewContentMaxLength)]
        public string ReviewContent { get; set; }

        [Range(ValidationConstants.ScoreMinValue, ValidationConstants.ScoreMaxValue)]
        public int Score { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public bool IsDeleted { get; set; }
    }
}
