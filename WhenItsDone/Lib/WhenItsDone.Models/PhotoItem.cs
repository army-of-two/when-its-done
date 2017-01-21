using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class PhotoItem : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsDeleted { get; set; }
    }
}
