using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class PhotoItem : IDbModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsDeleted { get; set; }
    }
}
