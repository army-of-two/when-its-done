using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ContactInformation : IDbModel
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
