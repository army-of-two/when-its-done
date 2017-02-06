using WhenItsDone.DTOs.AddressDTOs;

namespace WhenItsDone.DTOs.ContactInformationDTOs
{
    public class ContactInformationFullWithNestedDTO
    {
        public int Id { get; set; }

        public virtual AddressFullDTO Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
