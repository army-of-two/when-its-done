using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ProfilePicture : IDbModel
    {
        private ICollection<User> users;

        public ProfilePicture()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string PictureBase64 { get; set; }

        [MaxLength(ValidationConstants.UrlLengthMaxValue)]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(5)]
        public string MimeType { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }


        public bool IsDeleted { get; set; }
    }
}
