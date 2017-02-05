using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ProfilePicture : IDbModel
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

        public bool IsDeleted { get; set; }
    }
}
