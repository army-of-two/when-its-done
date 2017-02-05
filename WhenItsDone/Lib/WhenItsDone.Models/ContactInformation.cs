using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ContactInformation : IDbModel
    {
        private ICollection<Client> clients;

        public ContactInformation()
        {
            this.clients = new HashSet<Client>();
        }

        [Key]
        public int Id { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        [MinLength(ValidationConstants.EmailMinLength)]
        [MaxLength(ValidationConstants.EmailMaxLength)]
        [RegularExpression(RegexConstants.Email)]
        public string Email { get; set; }

        [MinLength(ValidationConstants.PhoneMinLength)]
        [MaxLength(ValidationConstants.PhoneMaxLength)]
        [RegularExpression(RegexConstants.Phone)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Client> Clients
        {
            get
            {
                return this.clients;
            }

            set
            {
                this.clients = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}
