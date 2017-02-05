using System.ComponentModel.DataAnnotations;

namespace WhenItsDone.Models
{
    public class ProfilePicture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PictureBase64 { get; set; }
    }
}
