using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public abstract class SurveyItem : PersistentEntity
    {
        public virtual int SequenceNo { get; set; }
        public virtual string Title { get; set; }

        public override string ToString()
        {
            return this.SequenceNo.ToString() + " " + this.Title;
        }

    }
}
