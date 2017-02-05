using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;

namespace WhenItsDone.Models
{
    public class ProfilePicture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PictureBase64 { get; set; }

        [MaxLength(ValidationConstants.UrlLengthMaxValue)]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(5)]
        public string MimeType { get; set; }
    }
}
