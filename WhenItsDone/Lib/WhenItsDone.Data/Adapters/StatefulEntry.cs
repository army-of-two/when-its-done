using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.Adapters
{
    public class Stateful<T> : IStateful<T>
    {
        private readonly DbEntityEntry entry;

        public Stateful(DbEntityEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("Entry");
            }

            this.entry = entry;
        }

        public EntityState State
        {
            get
            {
                return this.entry.State;
            }

            set
            {
                this.entry.State = value;
            }
        }
    }
}
