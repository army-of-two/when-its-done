using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WhenItsDone.Data.Contracts;

namespace WhenItsDone.Data.Adapters
{
    public class Stateful<T> : IStateful<T> where T : class
    {
        private readonly DbEntityEntry<T> entry;

        public Stateful(DbEntityEntry<T> entry)
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
