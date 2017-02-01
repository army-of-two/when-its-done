using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class User : IDbModel
    {
        // TODO: 
        public int Id { get; set; }

        public string Username { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public bool IsDeleted { get; set; }
    }
}
