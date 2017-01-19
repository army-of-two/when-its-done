using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ClientReview : IDbModel
    {
        public int Id { get; set; }

        public string ReviewContent { get; set; }

        public int Score { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public bool IsDeleted { get; set; }
    }
}
