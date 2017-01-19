using System.Collections.Generic;

using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Models
{
    public class Worker : IDbModel
    {
        public Worker()
        {
            this.Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsAvailable { get; set; }

        public int Rating { get; set; }

        public int ContactInformationId { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

        public virtual ICollection<Task> Tasks
        {
            get
            {
                return this.Tasks;
            }
            set
            {
                this.Tasks = value;

            }
        }

        public bool IsDeleted { get; set; }
    }
}
