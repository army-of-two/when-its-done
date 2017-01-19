using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ClientReview : IDbModel
    {
        public int Id { get; set; }

        public string ReviewContent { get; set; }

        public int Score { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public bool IsDeleted { get; set; }
    }
}
