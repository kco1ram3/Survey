using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey
{
    public class LikertItemResponse : PersistentEntity
    {
        public LikertItemResponse()
        {
        }

        public LikertItemResponse(Survey.LikertItem li, Choice choice)
        {
            this.LikertItem = li;
            this.Choice = choice;
        }

        public virtual LikertItem LikertItem { get; set; }

        public virtual int SequenceNo { get; set; }

        public virtual LikertResponse Parent { get; set; }

        public virtual Choice Choice { get; set; }
    }
}
