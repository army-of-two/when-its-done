using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Address : IDbModel
    {
        private ICollection<ContactInformation> contactInformations;

        public Address()
        {
            this.contactInformations = new HashSet<ContactInformation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.CountryMinLength)]
        [MaxLength(ValidationConstants.CountryMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string Country { get; set; }

        [Required]
        [MinLength(ValidationConstants.CityMinLength)]
        [MaxLength(ValidationConstants.CityMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string City { get; set; }

        [Required]
        [MinLength(ValidationConstants.StreetMinLength)]
        [MaxLength(ValidationConstants.StreetMaxLength)]
        [RegularExpression(RegexConstants.EnBgSpaceMinus)]
        public string Street { get; set; }

        public virtual ICollection<ContactInformation> ContactInformations
        {
            get
            {
                return this.contactInformations;
            }

            set
            {
                this.contactInformations = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
