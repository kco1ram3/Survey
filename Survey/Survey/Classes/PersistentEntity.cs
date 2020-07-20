using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public abstract class PersistentEntity
    {
        public virtual int ID { get; set; }

        public virtual void Persist(Context context)
        {
            context.Persist(this);
        }
    }
}
