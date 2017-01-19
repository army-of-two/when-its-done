using System.Collections.Generic;

using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Worker : IDbModel
    {
        public Worker()
        {
            this.Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsAvailable { get; set; }

        public int Rating { get; set; }

        public int ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public virtual ICollection<Job> Jobs
        {
            get
            {
                return this.Jobs;
            }
            set
            {
                this.Jobs = value;

            }
        }

        public bool IsDeleted { get; set; }
    }
}
