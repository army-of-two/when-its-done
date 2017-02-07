using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class VideoItem : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.UrlLengthMinLength)]
        [MaxLength(ValidationConstants.UrlLengthMaxValue)]
        public string YouTubeUrl { get; set; }

        public string YouTubeId { get; set; }

        public int Rating { get; set; }

        public bool IsDeleted { get; set; }
    }
}
