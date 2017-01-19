using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Address : IDbModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public bool IsDeleted { get; set; }
    }
}
