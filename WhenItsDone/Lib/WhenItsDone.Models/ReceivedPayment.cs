using System.ComponentModel.DataAnnotations;

using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class ReceivedPayment : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Range(ValidationConstants.AmountPaidMinValue, ValidationConstants.AmountPaidMaxValue)]
        public decimal AmountPaid { get; set; }
    }
}
