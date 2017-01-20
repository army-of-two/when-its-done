using System;
using System.ComponentModel.DataAnnotations;
using WhenItsDone.Models.Constants;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Job : IDbModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime ScheduledTime { get; set; }

        [Required]
        [Range(ValidationConstants.PriceMinValue, ValidationConstants.PriceMaxValue)]
        public decimal Price { get; set; }

        public int WorkerId { get; set; }

        public virtual Worker Worker { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
