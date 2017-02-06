using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ContactInformation : IDbModel
    {
        private ICollection<Worker> workers;
        private ICollection<Client> clients;
        private ICollection<User> users;

        public ContactInformation()
        {
            this.workers = new HashSet<Worker>();
            this.clients = new HashSet<Client>();
            this.users = new HashSet<User>();
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

        public virtual ICollection<Worker> Workers
        {
            get
            {
                return this.workers;
            }

            set
            {
                this.workers = value;
            }
        }

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
