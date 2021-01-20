using System;

namespace MLHDemosDatabaseCreation.Model
{
    public abstract class DatabaseEntity 
    {
        public virtual Guid Id { get; set; }

    }
}
