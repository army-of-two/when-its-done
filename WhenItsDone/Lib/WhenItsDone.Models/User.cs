using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class User : IDbModel
    {
        // TODO: 
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
